// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { ICidade } from '@/app/GerAdv_TS/Cidade/Interfaces/interface.Cidade';
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

import UFComboBox from '@/app/GerAdv_TS/UF/ComboBox/UF';
import { UFApi } from '@/app/GerAdv_TS/UF/Apis/ApiUF';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface CidadeFormProps {
    cidadeData: ICidade;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const CidadeForm: React.FC<CidadeFormProps> = ({
    cidadeData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeUF, setNomeUF] = useState('');
            const ufApi = new UFApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("uf") > 0) {
  ufApi
    .getById(getParamFromUrl("uf"))
    .then((response) => {
      setNomeUF(response.data.d);
    })
    .catch((error) => {
      console.error(error);
    });

  if (cidadeData.id === 0) {
    cidadeData.uf = getParamFromUrl("uf");
  }
}
 const addValorUF = (e: any) => {
                        if (e?.id>0)
                        cidadeData.uf = e.id;
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
        console.error("Erro ao submeter formulário de Cidade:", error);
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
          target: document.getElementById(`CidadeForm-${cidadeData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar Cidade diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-Cidade' : 'form-container5 form-container-Cidade'}>
       
            <form className='formInputCadInc' id={`CidadeForm-${cidadeData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={cidadeData} isSubmitting={isSubmitting} onClose={onClose} formId={`CidadeForm-${cidadeData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="Nome"
            className="inputIncNome"
            name="nome"
            value={cidadeData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
          />

<InputInput
type="text"
id="ddd"
label="DDD"
className="inputIncNome"
name="ddd"
value={cidadeData.ddd}
onChange={onChange}               
/>

<InputCheckbox label="Top" name="top" checked={cidadeData.top} onChange={onChange} />
<InputCheckbox label="Comarca" name="comarca" checked={cidadeData.comarca} onChange={onChange} />
<InputCheckbox label="Capital" name="capital" checked={cidadeData.capital} onChange={onChange} />
 
            <UFComboBox
            name={'uf'}
            value={cidadeData.uf}
            setValue={addValorUF}
            label={'UF'}
            />

<InputInput
type="text"
id="sigla"
label="Sigla"
className="inputIncNome"
name="sigla"
value={cidadeData.sigla}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 