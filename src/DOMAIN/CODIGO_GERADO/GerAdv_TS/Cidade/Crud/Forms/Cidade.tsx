// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { ICidade } from '@/app/GerAdv_TS/Cidade/Interfaces/interface.Cidade';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import UFComboBox from '@/app/GerAdv_TS/UF/ComboBox/UF';
import { UFApi } from '@/app/GerAdv_TS/UF/Apis/ApiUF';
import InputName from '@/app/components/Inputs/InputName';
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
    e.preventDefault();
    if (!isSubmitting) {
      setIsSubmitting(true);
      onSubmit(e);
    }
   };

  const onPressSalvar = (e: any) => {
    e.preventDefault();
    if (!isSubmitting) {
      const formElement = document.getElementById('CidadeForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`CidadeForm-${cidadeData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={cidadeData} isSubmitting={isSubmitting} onClose={onClose} formId={`CidadeForm-${cidadeData.id}`} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={cidadeData.nome}
            placeholder={`Digite nome cidade`}
            onChange={onChange}
            required
          />

<Input
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

<Input
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
        
    </>
     );
};
 