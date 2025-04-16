"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { ITribEnderecos } from '../../Interfaces/interface.TribEnderecos';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import TribunalComboBox from '@/app/GerAdv_TS/Tribunal/ComboBox/Tribunal';
import { TribunalApi } from '@/app/GerAdv_TS/Tribunal/Apis/ApiTribunal';
import InputCep from '@/app/components/Inputs/InputCep'

interface TribEnderecosFormProps {
    tribenderecosData: ITribEnderecos;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const TribEnderecosForm: React.FC<TribEnderecosFormProps> = ({
    tribenderecosData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeTribunal, setNomeTribunal] = useState('');
            const tribunalApi = new TribunalApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("tribunal") > 0) {
  tribunalApi
    .getById(getParamFromUrl("tribunal"))
    .then((response) => {
      setNomeTribunal(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (tribenderecosData.id === 0) {
    tribenderecosData.tribunal = getParamFromUrl("tribunal");
  }
}
 const addValorTribunal = (e: any) => {
                        if (e?.id>0)
                        tribenderecosData.tribunal = e.id;
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
  {nomeTribunal && (<h2>{nomeTribunal}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

            <TribunalComboBox
            name={'tribunal'}
            value={tribenderecosData.tribunal}
            setValue={addValorTribunal}
            label={'Tribunal'}
            />

<Input
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={tribenderecosData.cidade}
onChange={onChange}               
/>

<Input
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={tribenderecosData.endereco}
onChange={onChange}               
/>

<InputCep
type="text"
id="cep"
label="CEP"
className="inputIncNome"
name="cep"
value={tribenderecosData.cep}
onChange={onChange}               
/>

<Input
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={tribenderecosData.fone}
onChange={onChange}               
/>

<Input
type="text"
id="fax"
label="Fax"
className="inputIncNome"
name="fax"
value={tribenderecosData.fax}
onChange={onChange}               
/>

<Input
type="text"
id="obs"
label="OBS"
className="inputIncNome"
name="obs"
value={tribenderecosData.obs}
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
 