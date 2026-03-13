import React, { useEffect, useState } from 'react';
import * as Icons from '../svg/IconsAppointments';
import { useAppSelector } from '@/app/store/hooks';
import { selectSystemContext } from '@/app/store/slices/systemContextSlice';
import { TipoCompromissoApi } from '@/app/GerAdv_TS/TipoCompromisso/Apis/TipoCompromissoApi';
import { IAgenda } from '@/app/GerAdv_TS/Agenda/Interfaces/interface.Agenda';
import { useSwipeLeft } from '@/app/hooks/useSwipeLeft';

interface ViewMobileProps {
  /** Nome completo da pessoa */
  name: string;
  data: IAgenda,
  related?: any
  line1?: string;
  line2?: string;
  line1Caption?: string;
  line2Caption?: string;
  /** Tamanho do avatar em pixels */
  size?: number;
  /** Tamanho da fonte */
  fontSize?: string;
  /** Classes CSS adicionais */
  className?: string;
  /** Callback ao clicar no avatar */
  onClick?: (event: React.MouseEvent<HTMLDivElement>) => void;
}

/**
 * Componente SlimAvatar - versão simplificada para listagens e cadastros básicos
 * Mostra apenas as iniciais sem cores elaboradas, mais discreto
 */
const ViewMobileAgenda: React.FC<ViewMobileProps> = ({
  name,
  line1,
  line2,
  line1Caption,
  line2Caption,
  size = 64,
  fontSize = '28px',
  className = '',
  onClick,
  data
}) => {

  // Função para extrair primeira letra do primeiro e último nome
  const getInitials = (fullName: string): string => {
    if (!fullName || fullName.trim() === '') return '??';

    const nameParts = fullName.trim().split(' ').filter(part => part.length > 0);

    if (nameParts.length === 1) {
      return nameParts[0].substring(0, 2).toUpperCase();
    }

    const firstInitial = nameParts[0][0];
    const lastInitial = nameParts[nameParts.length - 1][0];

    return (firstInitial + lastInitial).toUpperCase();
  };

  // Função para gerar cor baseada no código ASCII das letras
  const generateColor = (initials: string): string => {
    if (!initials || initials.length < 2) return '#6B7280';

    const char1 = initials.charCodeAt(0);
    const char2 = initials.charCodeAt(1);

    const red = (char1 * 7 + char2 * 3) % 256;
    const green = (char1 * 5 + char2 * 11) % 256;
    const blue = (char1 * 13 + char2 * 17) % 256;

    const adjustBrightness = (value: number): number => {
      if (value < 80) return value + 80;
      if (value > 200) return value - 80;
      return value;
    };

    const adjustedRed = adjustBrightness(red);
    const adjustedGreen = adjustBrightness(green);
    const adjustedBlue = adjustBrightness(blue);

    return `rgb(${adjustedRed}, ${adjustedGreen}, ${adjustedBlue})`;
  };

  // Calcula a luminância para decidir se o texto deve ser branco ou preto
  const getLuminance = (rgbString: string): number => {
    const rgb = rgbString.match(/\d+/g)?.map(Number) || [0, 0, 0];
    const [r, g, b] = rgb.map(val => {
      val = val / 255;
      return val <= 0.03928 ? val / 12.92 : Math.pow((val + 0.055) / 1.055, 2.4);
    });
    return 0.2126 * r + 0.7152 * g + 0.0722 * b;
  };

  const initials = getInitials(name);
  const backgroundColor = generateColor(initials);
  const luminance = getLuminance(backgroundColor);
  const textColor = luminance > 0.5 ? '#000000' : '#FFFFFF';

  const systemContext = useAppSelector(selectSystemContext);

  const avatarStyle: React.CSSProperties = {
    width: `${size}px`,
    height: `${size}px`,
    borderRadius: '50%',
    backgroundColor: backgroundColor,
    color: textColor,
    display: 'inline-flex',
    alignItems: 'center',
    justifyContent: 'center',
    fontSize: fontSize,
    fontWeight: '600',
    fontFamily: 'Arial, sans-serif',
    userSelect: 'none',
    flexShrink: 0,
    cursor: onClick ? 'pointer' : 'default',
    transition: 'all 0.2s ease',
    verticalAlign: 'middle'
  };

  const handleClick = (event: React.MouseEvent<HTMLDivElement>) => {
    if (onClick) {      
      onClick(event);
    }
  };

 
  const [svgIcon, setSvgIcon] = useState<string | null>(null);

  useEffect(() => {
    let mounted = true;

    // Determine initial iconeIndex from props (fallback to 0)
    const providedIndex = typeof data?.tipocompromisso === 'number' && !isNaN(data.tipocompromisso) ? data.tipocompromisso : 0;

    const cacheKey = `TipoCompromisso_IconIndex_${providedIndex}`;

    const setFromIconsModule = (iconeIndex: number) => {
      const iconKey = `Icone${iconeIndex}${data?.concluido ? 'Ok' : ''}`;
      const fromBundle = (Icons as any)[iconKey] || (Icons as any).Icone0 || '';
      if (mounted) setSvgIcon(fromBundle);
    };

    // Try cached resolved iconeIndex first
    try {
      const cached = typeof window !== 'undefined' ? localStorage.getItem(cacheKey) : null;
      if (cached) {
        const cachedIndex = parseInt(cached, 10);
        setFromIconsModule(isNaN(cachedIndex) ? providedIndex : cachedIndex);
        return () => { mounted = false; };
      }
    } catch (e) {
      // ignore localStorage errors
    }

    // If no cache, use the existing TipoCompromissoApi to fetch the entity
    (async () => {
      try {
        if (!data?.tipocompromisso || data.tipocompromisso <= 0) {
          setFromIconsModule(providedIndex);
          return;
        }

        const tenant = systemContext?.TenantApp ?? '';
        const token = systemContext?.Token ?? '';

        const api = new TipoCompromissoApi(tenant, token);

        const resp = await api.getById(data.tipocompromisso);
        const tipoCompromissoData = resp?.data;
        const resolvedIndex = typeof tipoCompromissoData?.icone === 'number' ? tipoCompromissoData.icone : providedIndex;

        try {
          if (typeof window !== 'undefined') localStorage.setItem(cacheKey, String(resolvedIndex));
        } catch (e) {}

        setFromIconsModule(resolvedIndex);
      } catch (error) {
        setFromIconsModule(providedIndex);
      }
    })();

    return () => { mounted = false; };
  }, [data]);
  
    const { onTouchStart, onTouchEnd } = useSwipeLeft({
      threshold: 80,
      onSwipeLeft: () => {
        if (!onClick) return;
        try {
          (onClick as any)();
        } catch (err) {
          // fallback: try calling with an empty object but swallow errors
          try { onClick({} as any); } catch (e) {}
        }
      },
    });
    
  return (
    <>
      <div className='card-item' 
          onClick={handleClick}
          onTouchStart={onTouchStart}
          onTouchEnd={onTouchEnd}>
        <div className={size == 64 ? 'avatar-large' : 'avatar-slim'}>
          <div
            style={avatarStyle}
            className={className}
            title={name}
            role={onClick ? "button" : "img"}
            aria-label={name}            
            tabIndex={onClick ? 0 : undefined}
            onKeyDown={(e) => {
              if (onClick && (e.key === 'Enter' || e.key === ' ')) {
                e.preventDefault();
                onClick(e as any);
              }
            }}
          >
            {initials}
          </div>

        </div>
        <div className={size == 64 ? 'card-info' : 'card-info-slim'}>
          <h3 className='card-name'>{name}</h3>
          {line1 && <div className='card-item1' style={{ display: 'block' }}>{line1Caption && <span className='card-caption'>{line1Caption}: </span>}{line1}</div>}
          {line2 && <div className='card-item2' style={{ display: 'block' }}>{line2Caption && <span className='card-caption'>{line2Caption}: </span>}{line2}</div>}
        </div>
          {!!svgIcon && (
            <div className='card-agenda-icon' style={{ fontSize: size / 2 }}>
                <div className="svg-icon" dangerouslySetInnerHTML={{ __html: svgIcon }} />

            </div>
          )}
      </div>


      
      

    </>
  );
};

export default ViewMobileAgenda;
