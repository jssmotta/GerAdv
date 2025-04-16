"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IProPartes } from '../../Interfaces/interface.ProPartes';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';

interface ProPartesFormProps {
    propartesData: IProPartes;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ProPartesForm: React.FC<ProPartesFormProps> = ({
    propartesData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeProcessos, setNomeProcessos] = useState('');
            const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("processos") > 0) {
  processosApi
    .getById(getParamFromUrl("processos"))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

  if (propartesData.id === 0) {
    propartesData.processo = getParamFromUrl("processos");
  }
}
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        propartesData.processo = e.id;
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
  {nomeProcessos && (<h2>{nomeProcessos}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

<Input
type="text"
id="parte"
label="Parte"
className="inputIncNome"
name="parte"
value={propartesData.parte}
onChange={onChange}               
/>

            <ProcessosComboBox
            name={'processo'}
            value={propartesData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
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
 