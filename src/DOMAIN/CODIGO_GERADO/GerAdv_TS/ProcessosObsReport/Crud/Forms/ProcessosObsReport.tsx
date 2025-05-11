// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IProcessosObsReport } from '@/app/GerAdv_TS/ProcessosObsReport/Interfaces/interface.ProcessosObsReport';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import HistoricoComboBox from '@/app/GerAdv_TS/Historico/ComboBox/Historico';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import { HistoricoApi } from '@/app/GerAdv_TS/Historico/Apis/ApiHistorico';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'

interface ProcessosObsReportFormProps {
    processosobsreportData: IProcessosObsReport;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ProcessosObsReportForm: React.FC<ProcessosObsReportFormProps> = ({
    processosobsreportData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeProcessos, setNomeProcessos] = useState('');
            const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeHistorico, setNomeHistorico] = useState('');
            const historicoApi = new HistoricoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("processos") > 0) {
  processosApi
    .getById(getParamFromUrl("processos"))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

  if (processosobsreportData.id === 0) {
    processosobsreportData.processo = getParamFromUrl("processos");
  }
}
 
if (getParamFromUrl("historico") > 0) {
  historicoApi
    .getById(getParamFromUrl("historico"))
    .then((response) => {
      setNomeHistorico(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

  if (processosobsreportData.id === 0) {
    processosobsreportData.historico = getParamFromUrl("historico");
  }
}
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        processosobsreportData.processo = e.id;
                      };
 const addValorHistorico = (e: any) => {
                        if (e?.id>0)
                        processosobsreportData.historico = e.id;
                      };

    const onConfirm = (e: React.FormEvent) => {
    // Importante: prevenir comportamento padrão e propagação
    e.preventDefault();
    if (e.stopPropagation) e.stopPropagation();
    
    // Evitar múltiplos envios
    if (!isSubmitting) {
      setIsSubmitting(true);
      
      // Chamar onSubmit com o evento
      try {
        onSubmit(e);
      } catch (error) {
        console.error("Erro ao submeter formulário de ProcessosObsReport:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  // Handler para submissão direta via ButtonsCrud
  const handleDirectSave = () => {
    if (!isSubmitting) {
      setIsSubmitting(true);
      
      try {
        // Criar um evento sintético básico para manter compatibilidade
        const syntheticEvent = {
          preventDefault: () => { },
          target: document.getElementById(`ProcessosObsReportForm-${processosobsreportData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar ProcessosObsReport diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-ProcessosObsReport' : 'form-container5 form-container-ProcessosObsReport'}>
       
            <form className='formInputCadInc' id={`ProcessosObsReportForm-${processosobsreportData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={processosobsreportData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProcessosObsReportForm-${processosobsreportData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

<InputInput
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={processosobsreportData.data}
onChange={onChange}               
/>

            <ProcessosComboBox
            name={'processo'}
            value={processosobsreportData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

<InputInput
type="text"
id="observacao"
label="Observacao"
className="inputIncNome"
name="observacao"
value={processosobsreportData.observacao}
onChange={onChange}               
/>

            <HistoricoComboBox
            name={'historico'}
            value={processosobsreportData.historico}
            setValue={addValorHistorico}
            label={'Historico'}
            />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 