// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IUF } from '@/app/GerAdv_TS/UF/Interfaces/interface.UF';
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

import PaisesComboBox from '@/app/GerAdv_TS/Paises/ComboBox/Paises';
import { PaisesApi } from '@/app/GerAdv_TS/Paises/Apis/ApiPaises';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface UFFormProps {
    ufData: IUF;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const UFForm: React.FC<UFFormProps> = ({
    ufData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomePaises, setNomePaises] = useState('');
            const paisesApi = new PaisesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("paises") > 0) {
  paisesApi
    .getById(getParamFromUrl("paises"))
    .then((response) => {
      setNomePaises(response.data.inome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (ufData.id === 0) {
    ufData.pais = getParamFromUrl("paises");
  }
}
 const addValorPais = (e: any) => {
                        if (e?.id>0)
                        ufData.pais = e.id;
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
        console.error("Erro ao submeter formulário de UF:", error);
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
          target: document.getElementById(`UFForm-${ufData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar UF diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-UF' : 'form-container5 form-container-UF'}>
       
            <form className='formInputCadInc' id={`UFForm-${ufData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={ufData} isSubmitting={isSubmitting} onClose={onClose} formId={`UFForm-${ufData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="iduf"
            label="ID"
            className="inputIncNome"
            name="iduf"
            value={ufData.iduf}
            placeholder={`Informe ID`}
            onChange={onChange}
            required
          />

<InputInput
type="text"
id="ddd"
label="DDD"
className="inputIncNome"
name="ddd"
value={ufData.ddd}
onChange={onChange}               
/>

            <PaisesComboBox
            name={'pais'}
            value={ufData.pais}
            setValue={addValorPais}
            label={'Paises'}
            />

<InputCheckbox label="Top" name="top" checked={ufData.top} onChange={onChange} />
        
<InputInput
type="text"
id="descricao"
label="Descricao"
className="inputIncNome"
name="descricao"
value={ufData.descricao}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 