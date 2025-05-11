// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IReuniaoPessoas } from '@/app/GerAdv_TS/ReuniaoPessoas/Interfaces/interface.ReuniaoPessoas';
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

import ReuniaoComboBox from '@/app/GerAdv_TS/Reuniao/ComboBox/Reuniao';
import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import { ReuniaoApi } from '@/app/GerAdv_TS/Reuniao/Apis/ApiReuniao';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import InputName from '@/app/components/Inputs/InputName';

interface ReuniaoPessoasFormProps {
    reuniaopessoasData: IReuniaoPessoas;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ReuniaoPessoasForm: React.FC<ReuniaoPessoasFormProps> = ({
    reuniaopessoasData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeReuniao, setNomeReuniao] = useState('');
            const reuniaoApi = new ReuniaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeOperador, setNomeOperador] = useState('');
            const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("reuniao") > 0) {
  reuniaoApi
    .getById(getParamFromUrl("reuniao"))
    .then((response) => {
      setNomeReuniao(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

  if (reuniaopessoasData.id === 0) {
    reuniaopessoasData.reuniao = getParamFromUrl("reuniao");
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

  if (reuniaopessoasData.id === 0) {
    reuniaopessoasData.operador = getParamFromUrl("operador");
  }
}
 const addValorReuniao = (e: any) => {
                        if (e?.id>0)
                        reuniaopessoasData.reuniao = e.id;
                      };
 const addValorOperador = (e: any) => {
                        if (e?.id>0)
                        reuniaopessoasData.operador = e.id;
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
        console.error("Erro ao submeter formulário de ReuniaoPessoas:", error);
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
          target: document.getElementById(`ReuniaoPessoasForm-${reuniaopessoasData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar ReuniaoPessoas diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-ReuniaoPessoas' : 'form-container5 form-container-ReuniaoPessoas'}>
       
            <form className='formInputCadInc' id={`ReuniaoPessoasForm-${reuniaopessoasData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={reuniaopessoasData} isSubmitting={isSubmitting} onClose={onClose} formId={`ReuniaoPessoasForm-${reuniaopessoasData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

            <ReuniaoComboBox
            name={'reuniao'}
            value={reuniaopessoasData.reuniao}
            setValue={addValorReuniao}
            label={'Reuniao'}
            />

            <OperadorComboBox
            name={'operador'}
            value={reuniaopessoasData.operador}
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
 