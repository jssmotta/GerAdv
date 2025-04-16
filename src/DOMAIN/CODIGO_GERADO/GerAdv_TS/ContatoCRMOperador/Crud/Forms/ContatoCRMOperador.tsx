"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IContatoCRMOperador } from '../../Interfaces/interface.ContatoCRMOperador';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import ContatoCRMComboBox from '@/app/GerAdv_TS/ContatoCRM/ComboBox/ContatoCRM';
import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import { ContatoCRMApi } from '@/app/GerAdv_TS/ContatoCRM/Apis/ApiContatoCRM';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';

interface ContatoCRMOperadorFormProps {
    contatocrmoperadorData: IContatoCRMOperador;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ContatoCRMOperadorForm: React.FC<ContatoCRMOperadorFormProps> = ({
    contatocrmoperadorData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeContatoCRM, setNomeContatoCRM] = useState('');
            const contatocrmApi = new ContatoCRMApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeOperador, setNomeOperador] = useState('');
            const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("contatocrm") > 0) {
  contatocrmApi
    .getById(getParamFromUrl("contatocrm"))
    .then((response) => {
      setNomeContatoCRM(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

  if (contatocrmoperadorData.id === 0) {
    contatocrmoperadorData.contatocrm = getParamFromUrl("contatocrm");
  }
}
 
if (getParamFromUrl("operador") > 0) {
  operadorApi
    .getById(getParamFromUrl("operador"))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (contatocrmoperadorData.id === 0) {
    contatocrmoperadorData.operador = getParamFromUrl("operador");
  }
}
 const addValorContatoCRM = (e: any) => {
                        if (e?.id>0)
                        contatocrmoperadorData.contatocrm = e.id;
                      };
 const addValorOperador = (e: any) => {
                        if (e?.id>0)
                        contatocrmoperadorData.operador = e.id;
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
  {nomeContatoCRM && (<h2>{nomeContatoCRM}</h2>)}
{nomeOperador && (<h2>{nomeOperador}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

            <ContatoCRMComboBox
            name={'contatocrm'}
            value={contatocrmoperadorData.contatocrm}
            setValue={addValorContatoCRM}
            label={'Contato C R M'}
            />

<Input
type="text"
id="cargoesc"
label="CargoEsc"
className="inputIncNome"
name="cargoesc"
value={contatocrmoperadorData.cargoesc}
onChange={onChange}               
/>

            <OperadorComboBox
            name={'operador'}
            value={contatocrmoperadorData.operador}
            setValue={addValorOperador}
            label={'Operador'}
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
 