'use client';
import React from 'react';
import styles from '@/app/styles/AuditorModal.module.css';
import { Button } from '@progress/kendo-react-buttons';
// Use Kendo UI SVG icons via CSS classes (k-icon k-i-*) for corporate theme
import QuandoSoft from '../../utils/quandoSoft';
import { SvgIcon } from '@progress/kendo-react-common';
import { auditorIcon } from '../svg/auditorIcon';
// Official Kendo SVG icon objects (used by the corporate theme)
import { calendarIcon, pencilIcon, clockIcon } from '@progress/kendo-svg-icons';
import { useAppSelector } from '@/app/store/hooks';
import { selectSystemContext } from '@/app/store/slices/systemContextSlice';
import { AuditorApi } from '../msi/Auditor';
import { EditWindow } from './EditWindow';
import { useIsMobile } from '@/app/context/MobileContext';

export interface AuditorData {
  id: number;
  tableName: string;
  nomeQuemCadastrou: string;
  nomeQuemAlterou: string;
  dataHoraCadastro: string;
  dataHoraAlteracao: string;
  checked: boolean;
};

export interface AuditorModalProps {
  isOpen: boolean;
  auditor?: AuditorData | null;
  onConfirm: () => void;
  onCancel: () => void;
  title?: string;
  emojiTheme?: 'friendly' | 'corporate';
  entityName: string;
  id: number;
}

const fieldRow = (label: string, value?: React.ReactNode, icon?: React.ReactNode, isError = false) => (
  <div className={styles.row}>
    <div className={styles.label}><span style={{ marginRight: 8 }}>{icon}</span>{label}</div>
    <div className={`${styles.value} ${isError ? styles.haValue : ''}`}>{value ?? ''}</div>
  </div>
);

const AuditorModal: React.FC<AuditorModalProps> = ({
  isOpen,
  auditor,
  onConfirm,
  onCancel,
  title,
  emojiTheme,
  entityName,
  id,
}) => {

  const systemContext = useAppSelector(selectSystemContext);
  const isMobile = useIsMobile();
  const theme = emojiTheme ?? 'corporate';

  const auditorApi = new AuditorApi(systemContext?.TenantApp ?? '', systemContext?.Token ?? '');

  const [checked, setChecked] = React.useState<boolean>(auditor?.checked ?? false);

  const onAuditorCheck = () => {
    auditorApi.checkAuditor(entityName, id).then((data) => {
      setChecked(!!data);
    });
  };
  
  const renderIcon = (key: 'person' | 'clock' | 'hourglass' | 'pen' | 'calendar') => {
    if (theme === 'friendly') {
      const friendlyMap: Record<string, string> = { person: '👤', clock: '🕒', hourglass: '⏳', pen: '✍️', calendar: '📅' };
      return friendlyMap[key] ?? '';
    }

    // corporate theme: prefer official SVG icon objects rendered via SvgIcon
    if (key === 'person') return <SvgIcon icon={auditorIcon as any} className={styles.svgIcon} />;

    const svgMap: Record<string, any> = {
      clock: clockIcon,
      // hourglass not available in kendo bundle in this version — reuse clock as a visual substitute
      hourglass: clockIcon,
      pen: pencilIcon,
      calendar: calendarIcon,
    };

    const svgObj = svgMap[key];
    if (svgObj) {
      return <SvgIcon icon={svgObj as any} className={styles.svgIcon} />;
    }

    // final fallback: k-icon CSS classes (keeps visuals if package shape changes)
    const kendoMap: Record<string, string> = {
      clock: 'k-i-clock',
      hourglass: 'k-i-hourglass',
      pen: 'k-i-edit',
      calendar: 'k-i-calendar',
    };
    const kClass = kendoMap[key];
    return <span className={`k-icon ${kClass} ${styles.kIcon}`} aria-hidden />;
  };

  if (!isOpen) return null;

  const windowHeight = typeof window !== 'undefined' ? window.innerHeight : 800;
  const windowWidth = typeof window !== 'undefined' ? window.innerWidth : 400;

  return (
    <EditWindow
      tableTitle={(theme === 'friendly' ? '🧾 ' : '') + 'Auditor' + (title ? ` — ${title} - ${auditor?.id}` : '')}
      isOpen={isOpen}
      onClose={onCancel}
      dimensions={{
        width: isMobile ? windowWidth * 0.95 : 620,
        height: isMobile ? windowHeight * 0.8 : windowHeight,
      }}
      newWidth={isMobile ? undefined : 620}
      mobile={isMobile}
    >
      <div style={{ 
        display: 'flex', 
        flexDirection: 'column', 
        height: '95%',
        padding: isMobile ? '10px' : '15px'
      }}>
        <div className={styles.container}>
          {fieldRow('Quem Cadastrou', (
            <>
              <span>{auditor?.nomeQuemCadastrou ?? ''}</span>
              {auditor?.nomeQuemCadastrou == systemContext?.FirstName && (
                <> - <span className={styles.you}>{' Você'}</span></>
              )}
            </>
          ), renderIcon('person'))}

          <div className={styles.sep} />

          {fieldRow('Data / Hora Cadastro', auditor?.dataHoraCadastro ?? '', renderIcon('clock'))}
          {fieldRow('Há', QuandoSoft(auditor?.dataHoraCadastro ?? ''), renderIcon('calendar'), true)}

          <div className={styles.sep} />

          {fieldRow('Quem Alterou por último', (
            <>
              <span>{auditor?.nomeQuemAlterou ?? ''}</span>
              {auditor?.nomeQuemAlterou == systemContext?.FirstName && (
                <> - <span className={styles.you}>{' Você'}</span></>
              )}
            </>
          ), renderIcon('pen'))}
          {fieldRow('Data / Hora Última Alteração', auditor?.dataHoraAlteracao ?? '', renderIcon('clock'))}
          {fieldRow('Há', QuandoSoft(auditor?.dataHoraAlteracao ?? ''), renderIcon('calendar'), true)}
        </div>

        <div style={{ 
          display: 'flex', 
          gap: '10px', 
          justifyContent: 'flex-end',
          marginTop: '15px',
          paddingTop: '15px',
          borderTop: '1px solid #ccc'
        }}>
          {systemContext?.IsMaster === true && (
            <Button
              className="k-button"
              onClick={onAuditorCheck}
              aria-label={checked ? "Revisado" : "Marcar como Revisado"}
              disabled={checked}
            >
              {(checked ? '✅ Revisado' : 'Marcar como Revisado')}
            </Button>
          )}
          <Button
            className="k-button k-primary"
            onClick={onConfirm}
            aria-label="Fechar Auditoria" 
          >
            Fechar
          </Button>
        </div>
      </div>
    </EditWindow>
  );
}

export default AuditorModal;

// styles are provided via AuditorModal.module.css
