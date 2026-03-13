'use client';
import { EditWindow } from '@/app/components/Cruds/EditWindow';
import AtalhosGestos from '@/app/components/Cruds/Help/AtalhosGestos';
import FiltrosBusca from '@/app/components/Cruds/Help/FiltrosBusca';
import { HelpIcon, PlusIcon, FilterIcon, MicIcon, AIIcon, GridIcon, FullCardIcon, SmallCardIcon, ExcelIcon, PdfIcon } from '@/app/components/Cruds/Help/HelpIcons';
import { Section, HelpRow, ExplainBlock, DetailItem } from '@/app/components/Cruds/Help/HelpParts';
import NavegacaoInferior from '@/app/components/Cruds/Help/NavegacaoInferior';
import { useIsMobile } from '@/app/context/MobileContext';
import { useWindow } from '@/app/hooks/useWindows';
import { PMaxWidthHelpWindow } from '@/app/tools/help';
import '@/app/styles/HelpCrud.css';
import React from 'react';
import PrintHelpButton from './PrintHelpButton';

interface HelpCrudScreenProps {
  onBack?: () => void;
  title: string;
  lastUpdate?: string;
   whatsAppNumber?: string;
}

const HelpCrudScreen: React.FC<HelpCrudScreenProps> = ({ 
  onBack, 
  title, 
  lastUpdate,  
  whatsAppNumber = process.env.NEXT_PUBLIC_WHATSAPP_NUMBER || undefined
}) => {

  const dimensions = useWindow();
  const isMobile = useIsMobile();
  const [isOpen, setIsOpen] = React.useState(true);

  const onClose = () => {
    if (onBack) {
      onBack();
    }
    setIsOpen(false);
  };

  const whatsAppUrl = `https://wa.me/${whatsAppNumber}?text=${encodeURIComponent(
    `Olá, estou na ajuda e tenho dúvida sobre ${title}, poderia me ajudar?`
  )}`;
  
  return (
    <EditWindow
      tableTitle={`Ajuda`}
      isOpen={isOpen}
      onClose={onClose}
      dimensions={dimensions}
      maxWidth={PMaxWidthHelpWindow}
      mobile={isMobile}
      crud={true}
    >


      <div className="hc-root">
        <h1 className="hc-h1">{title}</h1>
        <Section title="Barra de Ferramentas">
          <HelpRow icon={<PlusIcon />} label="Novo registro" desc="Abre a tela de cadastro (CadInc) para criar uma nova consulta." />
          <HelpRow icon={<FilterIcon />} label="Filtrar" desc="Permite filtrar a listagem por data, paciente, status ou qualquer campo disponível." />
          <HelpRow icon={<MicIcon />} label="Busca por voz" desc="Ative o microfone e diga o nome do paciente ou a data. O sistema busca automaticamente." />


          <HelpRow icon={<ExcelIcon />} label="Exportar para Excel" desc="Exporta os dados da listagem para um arquivo Excel." />
          
          {!isMobile && (
            <HelpRow icon={<PdfIcon />} label="Exportar para PDF" desc="Exporta os dados da listagem para um arquivo PDF." />
            )}

          {isMobile && (<>

            <HelpRow icon={<GridIcon />} label="Visualização atual grid" desc="Alterna entre a visualização em cards (atual) e a visualização em tabela (grid)." />
            <HelpRow icon={<FullCardIcon />} label="Visualização atual card grande" desc="Alterna entre a visualização em cards pequenos, grandes e visualização em tabela (grid)." />
            <HelpRow icon={<SmallCardIcon />} label="Visualização atual card pequeno" desc="Alterna entre a visualização em cards pequenos, grandes e visualização em tabela (grid)." />

          </>)}

        <HelpRow icon={<HelpIcon />} label="Esta Ajuda" desc="Ajuda deste cadastro/tela." />

        </Section>

       {isMobile && (title=="Agenda" || title=="Consulta") && (
          <>
            <Section title="Cards de Consulta">
              <ExplainBlock>
                <p className="hc-infoText">Cada card representa uma consulta agendada ou realizada.</p>
                <div style={{ marginTop: 10 }}>
                  <DetailItem color="#C2727E" label="Iniciais" desc="Avatar com as iniciais. A cor é gerada automaticamente." />
                  <DetailItem color="#C8A84E" label="Nome" desc="Nome/Descrição. Toque no card para abrir os detalhes." />
                </div>
                <p className="hc-infoText">
                  <strong>Data e Hora</strong> — indicam quando a consulta foi agendada.
                </p>
              </ExplainBlock>
            </Section>
          </>
        )}

        {isMobile && (
          <>

            <Section title="Descrição dos cards">
              <ExplainBlock children={undefined} />
            </Section>
          </>
        )}
        <FiltrosBusca />
        {isMobile && (
          <>
            <AtalhosGestos />
            <NavegacaoInferior />
          </>)}

        <div className="hc-infoBox">
          <p className="hc-infoText">
            <strong>Dica:</strong> O espaçamento amplo entre os campos é intencional — ele reduz erros de toque, especialmente em dispositivos menores.
          </p>
        </div>
      </div>

      <style>{`@keyframes slideInRight { from { transform: translateX(100%); opacity: 0; } to { transform: translateX(0); opacity: 1; } }`}</style>
  
  
    {/* Footer */}
      <footer className="hc-footer"> 
        {lastUpdate && <span>&nbsp;—&nbsp;{lastUpdate}</span>}
        <PrintHelpButton lastUpdate={lastUpdate} />

      </footer>

           {/* WhatsApp CTA */}
      {whatsAppNumber && (
        <div className="hc-ctaWrap no-printer" title="Estamos disponíveis em horário comercial de Brasília">
          <p className="hc-ctaText">Ainda em dúvida? Ou gostaria de dar uma sugestão? Fale agora com a gente.</p>
          <a href={whatsAppUrl} target="_blank" rel="noopener noreferrer" className="hc-ctaBtn">
            <svg width="20" height="20" viewBox="0 0 24 24" fill="currentColor" style={{ flexShrink: 0 }}>
              <path d="M17.472 14.382c-.297-.149-1.758-.867-2.03-.967-.273-.099-.471-.148-.67.15-.197.297-.767.966-.94 1.164-.173.199-.347.223-.644.075-.297-.15-1.255-.463-2.39-1.475-.883-.788-1.48-1.761-1.653-2.059-.173-.297-.018-.458.13-.606.134-.133.298-.347.446-.52.149-.174.198-.298.298-.497.099-.198.05-.371-.025-.52-.075-.149-.669-1.612-.916-2.207-.242-.579-.487-.5-.669-.51-.173-.008-.371-.01-.57-.01-.198 0-.52.074-.792.372-.272.297-1.04 1.016-1.04 2.479 0 1.462 1.065 2.875 1.213 3.074.149.198 2.096 3.2 5.077 4.487.709.306 1.262.489 1.694.625.712.227 1.36.195 1.871.118.571-.085 1.758-.719 2.006-1.413.248-.694.248-1.289.173-1.413-.074-.124-.272-.198-.57-.347m-5.421 7.403h-.004a9.87 9.87 0 01-5.031-1.378l-.361-.214-3.741.982.998-3.648-.235-.374a9.86 9.86 0 01-1.51-5.26c.001-5.45 4.436-9.884 9.888-9.884 2.64 0 5.122 1.03 6.988 2.898a9.825 9.825 0 012.893 6.994c-.003 5.45-4.437 9.884-9.885 9.884m8.413-18.297A11.815 11.815 0 0012.05 0C5.495 0 .16 5.335.157 11.892c0 2.096.547 4.142 1.588 5.945L.057 24l6.305-1.654a11.882 11.882 0 005.683 1.448h.005c6.554 0 11.89-5.335 11.893-11.893a11.821 11.821 0 00-3.48-8.413z" />
            </svg>
            Nos chame no WhatsApp
          </a>
        </div>
      )}
      
    </EditWindow>
  );
};

export default HelpCrudScreen;
