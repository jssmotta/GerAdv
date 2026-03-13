import React from 'react';
import { useSwipeLeft } from '@/app/hooks/useSwipeLeft';

interface ViewMobileProps {
  name: string;
  data: any;
  related?: React.ReactNode;
  line1?: string;
  line2?: string;
  line1Caption?: string;
  line2Caption?: string;
  size?: number;
  fontSize?: string;
  className?: string;
  onClick?: (event: React.MouseEvent<HTMLDivElement>) => void;
}

/**
 * Componente SlimAvatar - versão simplificada para listagens e cadastros básicos
 * Mostra apenas as iniciais sem cores elaboradas, mais discreto
 */
const ViewMobile: React.FC<ViewMobileProps> = ({
  name,
  line1,
  line2,
  line1Caption,
  line2Caption,
  size = 64,
  fontSize = '28px',
  className = '',
  related,
  onClick
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
        <div className={size == 64 ? 'card-info' : 'card-info-slim'} onClick={handleClick}>
          <h3 className='card-name'>{name}</h3>
          {line1 && <div className='card-item1' style={{ display: 'block' }}>{line1Caption && <span className='card-caption'>{line1Caption}: </span>}{line1}</div>}
          {line2 && <div className='card-item2' style={{ display: 'block' }}>{line2Caption && <span className='card-caption'>{line2Caption}: </span>}{line2}</div>}
        </div>

         {!!related && (
            <div className='card-related-icon' style={{ fontSize: size }}>
                {related}
            </div>
          )}

      </div> 
    </>
  );
};

 
export default ViewMobile;