// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { INECompromissos } from '@/app/GerAdv_TS/NECompromissos/Interfaces/interface.NECompromissos';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import TipoCompromissoComboBox from '@/app/GerAdv_TS/TipoCompromisso/ComboBox/TipoCompromisso';
import { TipoCompromissoApi } from '@/app/GerAdv_TS/TipoCompromisso/Apis/ApiTipoCompromisso';
import InputName from '@/app/components/Inputs/InputName';
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface NECompromissosFormProps {
    necompromissosData: INECompromissos;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const NECompromissosForm: React.FC<NECompromissosFormProps> = ({
    necompromissosData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeTipoCompromisso, setNomeTipoCompromisso] = useState('');
            const tipocompromissoApi = new TipoCompromissoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("tipocompromisso") > 0) {
  tipocompromissoApi
    .getById(getParamFromUrl("tipocompromisso"))
    .then((response) => {
      setNomeTipoCompromisso(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

  if (necompromissosData.id === 0) {
    necompromissosData.tipocompromisso = getParamFromUrl("tipocompromisso");
  }
}
 const addValorTipoCompromisso = (e: any) => {
                        if (e?.id>0)
                        necompromissosData.tipocompromisso = e.id;
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
      const formElement = document.getElementById('NECompromissosForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`NECompromissosForm-${necompromissosData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={necompromissosData} isSubmitting={isSubmitting} onClose={onClose} formId={`NECompromissosForm-${necompromissosData.id}`} />

                <div className="grid-container">

<Input
type="text"
id="palavrachave"
label="PalavraChave"
className="inputIncNome"
name="palavrachave"
value={necompromissosData.palavrachave}
onChange={onChange}               
/>

<InputCheckbox label="Provisionar" name="provisionar" checked={necompromissosData.provisionar} onChange={onChange} />
 
            <TipoCompromissoComboBox
            name={'tipocompromisso'}
            value={necompromissosData.tipocompromisso}
            setValue={addValorTipoCompromisso}
            label={'Tipo Compromisso'}
            />

<Input
type="text"
id="textocompromisso"
label="TextoCompromisso"
className="inputIncNome"
name="textocompromisso"
value={necompromissosData.textocompromisso}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        
    </>
     );
};
 