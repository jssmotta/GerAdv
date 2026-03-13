'use client';

import React, { useEffect } from 'react';
import '@/app/styles/HelpMenuIcons.css';
import { SvgIcon } from '@progress/kendo-react-common';
import { gridIcon, copyIcon, questionCircleIcon, printIcon, trashIcon } from '@progress/kendo-svg-icons';
import { auditorIcon } from '../../svg/auditorIcon';
import { useHelp } from './HelpContext';

interface MenuItem {
  icon: React.ReactNode;
  title: string;
  description: string;
  variant: 'default' | 'danger' | 'whatsapp';
}

const HelpMenuIcons: React.FC = () => {

  const items: MenuItem[] = [
    {
      icon: (
        <SvgIcon icon={gridIcon} />
      ),
      title: 'Abrir cadastro geral',
      description: 'Abre a listagem completa dos registros deste cadastro.',
      variant: 'default',
    },
    {
      icon: (
        <SvgIcon icon={copyIcon} />
      ),
      title: 'Copiar dados para a memória',
      description: 'Copia os dados deste registro para usar em outros aplicativos.',
      variant: 'default',
    },
    {
      icon: (
       <SvgIcon icon={printIcon} />
      ),
      title: 'Imprimir este formulário',
      description: 'Gera uma versão para impressão com os dados atuais do registro.',
      variant: 'default',
    },
    {
      icon: (
       <SvgIcon icon={auditorIcon} />
      ),
      title: 'Abrir o Auditor',
      description: 'Exibe quem criou, quem alterou e quando este registro foi modificado. Permite marcar como revisado.',
      variant: 'default',
    },
    {
      icon: (
        <SvgIcon icon={trashIcon} />
      ),
      title: 'Excluir definitivamente',
      description: 'Remove este registro permanentemente. Esta ação não pode ser desfeita.',
      variant: 'danger',
    },
    {
      icon: (
       <SvgIcon icon={questionCircleIcon} />
      ),
      title: 'Esta Ajuda',
      description: 'Abre este painel com a documentação dos campos e opções disponíveis.',
      variant: 'default',
    },
    {
      icon: (
        <img
                src={process.env.NEXT_PUBLIC_LOGO_CONTATO}
                alt="WhatsApp"
                style={{ width: '18px', height: '18px' }}
            />
      ),
      title: 'Suporte no WhatsApp',
      description: 'Fale diretamente com nossa equipe para tirar dúvidas ou reportar problemas.',
      variant: 'whatsapp',
    },
  ];

  const { shown, setShown } = useHelp();

  useEffect(() => {
    if (!shown) setShown(true);
  }, [shown, setShown]);

  return (
    <div className="hmi-root">
      {!shown && (
        <div className="hmi-header">
          <p className="hmi-header-label">Barra de ferramentas</p>
          <p className="hmi-header-title">Você está na edição de registro. Conheça suas opções do docker de comandos:</p>
        </div>
      )}

      <div className="hmi-list">
        {items.map((item, idx) => (
          <div
            key={idx}
            className={`hmi-item ${idx < items.length - 1 ? 'hmi-item--bordered' : ''}`}
          >
            <div className={`hmi-icon hmi-icon--${item.variant}`}>
              {item.icon}
            </div>
            <div className="hmi-content">
              <p className={`hmi-title hmi-title--${item.variant}`}>{item.title}</p>
              <p className="hmi-description">{item.description}</p>
            </div>
            <kbd className={`hmi-badge hmi-badge--${item.variant} no-printer`}>{idx + 1}º</kbd>
          </div>
        ))}
      </div>
    </div>
  );
};

export default HelpMenuIcons;
