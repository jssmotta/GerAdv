// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IOperadorGrupo } from '@/app/GerAdv_TS/OperadorGrupo/Interfaces/interface.OperadorGrupo';
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

import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface OperadorGrupoFormProps {
    operadorgrupoData: IOperadorGrupo;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const OperadorGrupoForm: React.FC<OperadorGrupoFormProps> = ({
    operadorgrupoData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeOperador, setNomeOperador] = useState('');
            const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("operador") > 0) {
  operadorApi
    .getById(getParamFromUrl("operador"))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (operadorgrupoData.id === 0) {
    operadorgrupoData.operador = getParamFromUrl("operador");
  }
}
 const addValorOperador = (e: any) => {
                        if (e?.id>0)
                        operadorgrupoData.operador = e.id;
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
        console.error("Erro ao submeter formulário de OperadorGrupo:", error);
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
          target: document.getElementById(`OperadorGrupoForm-${operadorgrupoData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar OperadorGrupo diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-OperadorGrupo' : 'form-container5 form-container-OperadorGrupo'}>
       
            <form className='formInputCadInc' id={`OperadorGrupoForm-${operadorgrupoData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={operadorgrupoData} isSubmitting={isSubmitting} onClose={onClose} formId={`OperadorGrupoForm-${operadorgrupoData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

            <OperadorComboBox
            name={'operador'}
            value={operadorgrupoData.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />

<InputInput
type="text"
id="grupo"
label="Grupo"
className="inputIncNome"
name="grupo"
value={operadorgrupoData.grupo}
onChange={onChange}               
/>

<InputCheckbox label="Inativo" name="inativo" checked={operadorgrupoData.inativo} onChange={onChange} />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 