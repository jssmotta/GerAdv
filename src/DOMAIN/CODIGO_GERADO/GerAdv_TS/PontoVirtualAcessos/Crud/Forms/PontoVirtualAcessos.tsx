// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IPontoVirtualAcessos } from '@/app/GerAdv_TS/PontoVirtualAcessos/Interfaces/interface.PontoVirtualAcessos';
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

interface PontoVirtualAcessosFormProps {
    pontovirtualacessosData: IPontoVirtualAcessos;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const PontoVirtualAcessosForm: React.FC<PontoVirtualAcessosFormProps> = ({
    pontovirtualacessosData,
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

  if (pontovirtualacessosData.id === 0) {
    pontovirtualacessosData.operador = getParamFromUrl("operador");
  }
}
 const addValorOperador = (e: any) => {
                        if (e?.id>0)
                        pontovirtualacessosData.operador = e.id;
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
        console.error("Erro ao submeter formulário de PontoVirtualAcessos:", error);
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
          target: document.getElementById(`PontoVirtualAcessosForm-${pontovirtualacessosData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar PontoVirtualAcessos diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-PontoVirtualAcessos' : 'form-container5 form-container-PontoVirtualAcessos'}>
       
            <form className='formInputCadInc' id={`PontoVirtualAcessosForm-${pontovirtualacessosData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={pontovirtualacessosData} isSubmitting={isSubmitting} onClose={onClose} formId={`PontoVirtualAcessosForm-${pontovirtualacessosData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

            <OperadorComboBox
            name={'operador'}
            value={pontovirtualacessosData.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />

<InputInput
type="text"
id="datahora"
label="DataHora"
className="inputIncNome"
name="datahora"
value={pontovirtualacessosData.datahora}
onChange={onChange}               
/>

<InputCheckbox label="Tipo" name="tipo" checked={pontovirtualacessosData.tipo} onChange={onChange} />
        
<InputInput
type="text"
id="origem"
label="Origem"
className="inputIncNome"
name="origem"
value={pontovirtualacessosData.origem}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 