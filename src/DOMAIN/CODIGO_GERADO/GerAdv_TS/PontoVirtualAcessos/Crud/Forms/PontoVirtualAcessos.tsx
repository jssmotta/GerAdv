"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IPontoVirtualAcessos } from '../../Interfaces/interface.PontoVirtualAcessos';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';

interface PontoVirtualAcessosFormProps {
    pontovirtualacessosData: IPontoVirtualAcessos;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const PontoVirtualAcessosForm: React.FC<PontoVirtualAcessosFormProps> = ({
    pontovirtualacessosData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeOperador, setNomeOperador] = useState('');
            const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("operador") > 0) {
  operadorApi
    .getById(getParamFromUrl("operador"))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (pontovirtualacessosData.id === 0) {
    pontovirtualacessosData.operador = getParamFromUrl("operador");
  }
}
 const addValorOperador = (e: any) => {
                        if (e?.id>0)
                        pontovirtualacessosData.operador = e.id;
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
  {nomeOperador && (<h2>{nomeOperador}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

            <OperadorComboBox
            name={'operador'}
            value={pontovirtualacessosData.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />

<Input
type="text"
id="datahora"
label="DataHora"
className="inputIncNome"
name="datahora"
value={pontovirtualacessosData.datahora}
onChange={onChange}               
/>

<Checkbox label="Tipo" name="tipo" checked={pontovirtualacessosData.tipo} onChange={onChange} />
        
<Input
type="text"
id="origem"
label="Origem"
className="inputIncNome"
name="origem"
value={pontovirtualacessosData.origem}
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
 