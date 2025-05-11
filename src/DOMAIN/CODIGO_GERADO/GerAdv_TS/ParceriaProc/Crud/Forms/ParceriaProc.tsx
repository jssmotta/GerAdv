// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IParceriaProc } from '@/app/GerAdv_TS/ParceriaProc/Interfaces/interface.ParceriaProc';
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

import AdvogadosComboBox from '@/app/GerAdv_TS/Advogados/ComboBox/Advogados';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { AdvogadosApi } from '@/app/GerAdv_TS/Advogados/Apis/ApiAdvogados';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import InputName from '@/app/components/Inputs/InputName';

interface ParceriaProcFormProps {
    parceriaprocData: IParceriaProc;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ParceriaProcForm: React.FC<ParceriaProcFormProps> = ({
    parceriaprocData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeAdvogados, setNomeAdvogados] = useState('');
            const advogadosApi = new AdvogadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeProcessos, setNomeProcessos] = useState('');
            const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("advogados") > 0) {
  advogadosApi
    .getById(getParamFromUrl("advogados"))
    .then((response) => {
      setNomeAdvogados(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (parceriaprocData.id === 0) {
    parceriaprocData.advogado = getParamFromUrl("advogados");
  }
}
 
if (getParamFromUrl("processos") > 0) {
  processosApi
    .getById(getParamFromUrl("processos"))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

  if (parceriaprocData.id === 0) {
    parceriaprocData.processo = getParamFromUrl("processos");
  }
}
 const addValorAdvogado = (e: any) => {
                        if (e?.id>0)
                        parceriaprocData.advogado = e.id;
                      };
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        parceriaprocData.processo = e.id;
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
        console.error("Erro ao submeter formulário de ParceriaProc:", error);
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
          target: document.getElementById(`ParceriaProcForm-${parceriaprocData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar ParceriaProc diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-ParceriaProc' : 'form-container5 form-container-ParceriaProc'}>
       
            <form className='formInputCadInc' id={`ParceriaProcForm-${parceriaprocData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={parceriaprocData} isSubmitting={isSubmitting} onClose={onClose} formId={`ParceriaProcForm-${parceriaprocData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

            <AdvogadosComboBox
            name={'advogado'}
            value={parceriaprocData.advogado}
            setValue={addValorAdvogado}
            label={'Advogados'}
            />

            <ProcessosComboBox
            name={'processo'}
            value={parceriaprocData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 