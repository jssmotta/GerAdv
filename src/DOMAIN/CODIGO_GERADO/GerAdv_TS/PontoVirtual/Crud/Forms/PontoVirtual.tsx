// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IPontoVirtual } from '@/app/GerAdv_TS/PontoVirtual/Interfaces/interface.PontoVirtual';
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

interface PontoVirtualFormProps {
    pontovirtualData: IPontoVirtual;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const PontoVirtualForm: React.FC<PontoVirtualFormProps> = ({
    pontovirtualData,
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

  if (pontovirtualData.id === 0) {
    pontovirtualData.operador = getParamFromUrl("operador");
  }
}
 const addValorOperador = (e: any) => {
                        if (e?.id>0)
                        pontovirtualData.operador = e.id;
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
        console.error("Erro ao submeter formulário de PontoVirtual:", error);
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
          target: document.getElementById(`PontoVirtualForm-${pontovirtualData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar PontoVirtual diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-PontoVirtual' : 'form-container5 form-container-PontoVirtual'}>
       
            <form className='formInputCadInc' id={`PontoVirtualForm-${pontovirtualData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={pontovirtualData} isSubmitting={isSubmitting} onClose={onClose} formId={`PontoVirtualForm-${pontovirtualData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

<InputInput
type="text"
id="horaentrada"
label="HoraEntrada"
className="inputIncNome"
name="horaentrada"
value={pontovirtualData.horaentrada}
onChange={onChange}               
/>

<InputInput
type="text"
id="horasaida"
label="HoraSaida"
className="inputIncNome"
name="horasaida"
value={pontovirtualData.horasaida}
onChange={onChange}               
/>

            <OperadorComboBox
            name={'operador'}
            value={pontovirtualData.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />

<InputInput
type="text"
id="key"
label="Key"
className="inputIncNome"
name="key"
value={pontovirtualData.key}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 