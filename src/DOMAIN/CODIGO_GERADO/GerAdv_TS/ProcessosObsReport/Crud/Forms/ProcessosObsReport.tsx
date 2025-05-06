// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IProcessosObsReport } from '@/app/GerAdv_TS/ProcessosObsReport/Interfaces/interface.ProcessosObsReport';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import HistoricoComboBox from '@/app/GerAdv_TS/Historico/ComboBox/Historico';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import { HistoricoApi } from '@/app/GerAdv_TS/Historico/Apis/ApiHistorico';
import InputName from '@/app/components/Inputs/InputName';

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
    e.preventDefault();
    if (!isSubmitting) {
      setIsSubmitting(true);
      onSubmit(e);
    }
   };

  const onPressSalvar = (e: any) => {
    e.preventDefault();
    if (!isSubmitting) {
      const formElement = document.getElementById('ProcessosObsReportForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`ProcessosObsReportForm-${processosobsreportData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={processosobsreportData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProcessosObsReportForm-${processosobsreportData.id}`} />

                <div className="grid-container">

<Input
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

<Input
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
        
    </>
     );
};
 