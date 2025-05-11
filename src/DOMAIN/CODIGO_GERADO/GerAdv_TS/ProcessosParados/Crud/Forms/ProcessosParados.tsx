// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IProcessosParados } from '@/app/GerAdv_TS/ProcessosParados/Interfaces/interface.ProcessosParados';
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
import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'

interface ProcessosParadosFormProps {
    processosparadosData: IProcessosParados;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ProcessosParadosForm: React.FC<ProcessosParadosFormProps> = ({
    processosparadosData,
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
const [nomeOperador, setNomeOperador] = useState('');
            const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("processos") > 0) {
  processosApi
    .getById(getParamFromUrl("processos"))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

  if (processosparadosData.id === 0) {
    processosparadosData.processo = getParamFromUrl("processos");
  }
}
 
if (getParamFromUrl("operador") > 0) {
  operadorApi
    .getById(getParamFromUrl("operador"))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (processosparadosData.id === 0) {
    processosparadosData.operador = getParamFromUrl("operador");
  }
}
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        processosparadosData.processo = e.id;
                      };
 const addValorOperador = (e: any) => {
                        if (e?.id>0)
                        processosparadosData.operador = e.id;
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
        console.error("Erro ao submeter formulário de ProcessosParados:", error);
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
          target: document.getElementById(`ProcessosParadosForm-${processosparadosData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar ProcessosParados diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-ProcessosParados' : 'form-container5 form-container-ProcessosParados'}>
       
            <form className='formInputCadInc' id={`ProcessosParadosForm-${processosparadosData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={processosparadosData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProcessosParadosForm-${processosparadosData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

            <ProcessosComboBox
            name={'processo'}
            value={processosparadosData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

<InputInput
type="text"
id="semana"
label="Semana"
className="inputIncNome"
name="semana"
value={processosparadosData.semana}
onChange={onChange}               
/>

<InputInput
type="text"
id="ano"
label="Ano"
className="inputIncNome"
name="ano"
value={processosparadosData.ano}
onChange={onChange}               
/>

<InputInput
type="text"
id="datahora"
label="DataHora"
className="inputIncNome"
name="datahora"
value={processosparadosData.datahora}
onChange={onChange}               
/>

            <OperadorComboBox
            name={'operador'}
            value={processosparadosData.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />

<InputInput
type="text"
id="datahistorico"
label="DataHistorico"
className="inputIncNome"
name="datahistorico"
value={processosparadosData.datahistorico}
onChange={onChange}               
/>

<InputInput
type="text"
id="datanenotas"
label="DataNENotas"
className="inputIncNome"
name="datanenotas"
value={processosparadosData.datanenotas}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 