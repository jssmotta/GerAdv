// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IGUTMatriz } from '@/app/GerAdv_TS/GUTMatriz/Interfaces/interface.GUTMatriz';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import GUTTipoComboBox from '@/app/GerAdv_TS/GUTTipo/ComboBox/GUTTipo';
import { GUTTipoApi } from '@/app/GerAdv_TS/GUTTipo/Apis/ApiGUTTipo';
import InputDescription from '@/app/components/Inputs/InputDescription';

interface GUTMatrizFormProps {
    gutmatrizData: IGUTMatriz;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const GUTMatrizForm: React.FC<GUTMatrizFormProps> = ({
    gutmatrizData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeGUTTipo, setNomeGUTTipo] = useState('');
            const guttipoApi = new GUTTipoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("guttipo") > 0) {
  guttipoApi
    .getById(getParamFromUrl("guttipo"))
    .then((response) => {
      setNomeGUTTipo(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (gutmatrizData.id === 0) {
    gutmatrizData.guttipo = getParamFromUrl("guttipo");
  }
}
 const addValorGUTTipo = (e: any) => {
                        if (e?.id>0)
                        gutmatrizData.guttipo = e.id;
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
      const formElement = document.getElementById('GUTMatrizForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`GUTMatrizForm-${gutmatrizData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={gutmatrizData} isSubmitting={isSubmitting} onClose={onClose} formId={`GUTMatrizForm-${gutmatrizData.id}`} />

                <div className="grid-container">

    <InputDescription
            type="text"            
            id="descricao"
            label="descricao"
            className="inputIncNome"
            name="descricao"
            value={gutmatrizData.descricao}
            placeholder={`Digite nome g u t matriz`}
            onChange={onChange}
            required
            disabled={gutmatrizData.id > 0}
          />

            <GUTTipoComboBox
            name={'guttipo'}
            value={gutmatrizData.guttipo}
            setValue={addValorGUTTipo}
            label={'G U T Tipo'}
            />

<Input
type="text"
id="valor"
label="Valor"
className="inputIncNome"
name="valor"
value={gutmatrizData.valor}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        
    </>
     );
};
 