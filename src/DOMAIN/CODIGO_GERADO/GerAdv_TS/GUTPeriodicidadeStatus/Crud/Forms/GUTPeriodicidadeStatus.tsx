"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IGUTPeriodicidadeStatus } from '../../Interfaces/interface.GUTPeriodicidadeStatus';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import GUTAtividadesComboBox from '@/app/GerAdv_TS/GUTAtividades/ComboBox/GUTAtividades';
import { GUTAtividadesApi } from '@/app/GerAdv_TS/GUTAtividades/Apis/ApiGUTAtividades';

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

  return (
  <>
  {nomeGUTAtividades && (<h2>{nomeGUTAtividades}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
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
           <div className="buttons-container">
              <br />
              <Button type="button" className="buttonSair" onClick={onClose}>
                Cancelar
              </Button>
              &nbsp;&nbsp;
              <Button type="submit" themeColor="primary" className="buttonOk" disabled={isSubmitting}>
                Salvar
              </Button>
          </div>
        </form>
    </div>
    </>
     );
};
 