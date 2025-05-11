// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IOperadorGruposAgendaOperadores } from '@/app/GerAdv_TS/OperadorGruposAgendaOperadores/Interfaces/interface.OperadorGruposAgendaOperadores';
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

import OperadorGruposAgendaComboBox from '@/app/GerAdv_TS/OperadorGruposAgenda/ComboBox/OperadorGruposAgenda';
import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import { OperadorGruposAgendaApi } from '@/app/GerAdv_TS/OperadorGruposAgenda/Apis/ApiOperadorGruposAgenda';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import InputName from '@/app/components/Inputs/InputName';

interface OperadorGruposAgendaOperadoresFormProps {
    operadorgruposagendaoperadoresData: IOperadorGruposAgendaOperadores;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const OperadorGruposAgendaOperadoresForm: React.FC<OperadorGruposAgendaOperadoresFormProps> = ({
    operadorgruposagendaoperadoresData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeOperadorGruposAgenda, setNomeOperadorGruposAgenda] = useState('');
            const operadorgruposagendaApi = new OperadorGruposAgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeOperador, setNomeOperador] = useState('');
            const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("operadorgruposagenda") > 0) {
  operadorgruposagendaApi
    .getById(getParamFromUrl("operadorgruposagenda"))
    .then((response) => {
      setNomeOperadorGruposAgenda(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (operadorgruposagendaoperadoresData.id === 0) {
    operadorgruposagendaoperadoresData.operadorgruposagenda = getParamFromUrl("operadorgruposagenda");
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

  if (operadorgruposagendaoperadoresData.id === 0) {
    operadorgruposagendaoperadoresData.operador = getParamFromUrl("operador");
  }
}
 const addValorOperadorGruposAgenda = (e: any) => {
                        if (e?.id>0)
                        operadorgruposagendaoperadoresData.operadorgruposagenda = e.id;
                      };
 const addValorOperador = (e: any) => {
                        if (e?.id>0)
                        operadorgruposagendaoperadoresData.operador = e.id;
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
        console.error("Erro ao submeter formulário de OperadorGruposAgendaOperadores:", error);
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
          target: document.getElementById(`OperadorGruposAgendaOperadoresForm-${operadorgruposagendaoperadoresData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar OperadorGruposAgendaOperadores diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-OperadorGruposAgendaOperadores' : 'form-container5 form-container-OperadorGruposAgendaOperadores'}>
       
            <form className='formInputCadInc' id={`OperadorGruposAgendaOperadoresForm-${operadorgruposagendaoperadoresData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={operadorgruposagendaoperadoresData} isSubmitting={isSubmitting} onClose={onClose} formId={`OperadorGruposAgendaOperadoresForm-${operadorgruposagendaoperadoresData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

            <OperadorGruposAgendaComboBox
            name={'operadorgruposagenda'}
            value={operadorgruposagendaoperadoresData.operadorgruposagenda}
            setValue={addValorOperadorGruposAgenda}
            label={'Operador Grupos Agenda'}
            />

            <OperadorComboBox
            name={'operador'}
            value={operadorgruposagendaoperadoresData.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 