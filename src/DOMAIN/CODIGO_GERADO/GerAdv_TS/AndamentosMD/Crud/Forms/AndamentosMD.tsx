"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IAndamentosMD } from '../../Interfaces/interface.AndamentosMD';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';

interface AndamentosMDFormProps {
    andamentosmdData: IAndamentosMD;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const AndamentosMDForm: React.FC<AndamentosMDFormProps> = ({
    andamentosmdData,
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

  if (andamentosmdData.id === 0) {
    andamentosmdData.processo = getParamFromUrl("processos");
  }
}
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        andamentosmdData.processo = e.id;
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
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={andamentosmdData.nome}
            onChange={onChange}
            required
          />

            <ProcessosComboBox
            name={'processo'}
            value={andamentosmdData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

<Input
type="text"
id="andamento"
label="Andamento"
className="inputIncNome"
name="andamento"
value={andamentosmdData.andamento}
onChange={onChange}               
/>

<Input
type="text"
id="pathfull"
label="PathFull"
className="inputIncNome"
name="pathfull"
value={andamentosmdData.pathfull}
onChange={onChange}               
/>

<Input
type="text"
id="unc"
label="UNC"
className="inputIncNome"
name="unc"
value={andamentosmdData.unc}
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
 