// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IGUTPeriodicidadeStatus } from '@/app/GerAdv_TS/GUTPeriodicidadeStatus/Interfaces/interface.GUTPeriodicidadeStatus';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import GUTAtividadesComboBox from '@/app/GerAdv_TS/GUTAtividades/ComboBox/GUTAtividades';
import { GUTAtividadesApi } from '@/app/GerAdv_TS/GUTAtividades/Apis/ApiGUTAtividades';
import InputName from '@/app/components/Inputs/InputName';

interface GUTPeriodicidadeStatusFormProps {
    gutperiodicidadestatusData: IGUTPeriodicidadeStatus;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const GUTPeriodicidadeStatusForm: React.FC<GUTPeriodicidadeStatusFormProps> = ({
    gutperiodicidadestatusData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeGUTAtividades, setNomeGUTAtividades] = useState('');
            const gutatividadesApi = new GUTAtividadesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("gutatividades") > 0) {
  gutatividadesApi
    .getById(getParamFromUrl("gutatividades"))
    .then((response) => {
      setNomeGUTAtividades(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (gutperiodicidadestatusData.id === 0) {
    gutperiodicidadestatusData.gutatividade = getParamFromUrl("gutatividades");
  }
}
 const addValorGUTAtividade = (e: any) => {
                        if (e?.id>0)
                        gutperiodicidadestatusData.gutatividade = e.id;
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
      const formElement = document.getElementById('GUTPeriodicidadeStatusForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`GUTPeriodicidadeStatusForm-${gutperiodicidadestatusData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={gutperiodicidadestatusData} isSubmitting={isSubmitting} onClose={onClose} formId={`GUTPeriodicidadeStatusForm-${gutperiodicidadestatusData.id}`} />

                <div className="grid-container">

            <GUTAtividadesComboBox
            name={'gutatividade'}
            value={gutperiodicidadestatusData.gutatividade}
            setValue={addValorGUTAtividade}
            label={'G U T Atividades'}
            />

<Input
type="text"
id="datarealizado"
label="DataRealizado"
className="inputIncNome"
name="datarealizado"
value={gutperiodicidadestatusData.datarealizado}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        
    </>
     );
};
 