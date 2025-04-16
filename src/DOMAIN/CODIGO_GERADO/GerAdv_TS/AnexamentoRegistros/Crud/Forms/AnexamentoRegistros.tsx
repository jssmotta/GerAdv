"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IAnexamentoRegistros } from '../../Interfaces/interface.AnexamentoRegistros';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';

interface AnexamentoRegistrosFormProps {
    anexamentoregistrosData: IAnexamentoRegistros;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const AnexamentoRegistrosForm: React.FC<AnexamentoRegistrosFormProps> = ({
    anexamentoregistrosData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeClientes, setNomeClientes] = useState('');
            const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("clientes") > 0) {
  clientesApi
    .getById(getParamFromUrl("clientes"))
    .then((response) => {
      setNomeClientes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (anexamentoregistrosData.id === 0) {
    anexamentoregistrosData.cliente = getParamFromUrl("clientes");
  }
}
 const addValorCliente = (e: any) => {
                        if (e?.id>0)
                        anexamentoregistrosData.cliente = e.id;
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
  {nomeClientes && (<h2>{nomeClientes}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

            <ClientesComboBox
            name={'cliente'}
            value={anexamentoregistrosData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

<Input
type="text"
id="codigoreg"
label="CodigoReg"
className="inputIncNome"
name="codigoreg"
value={anexamentoregistrosData.codigoreg}
onChange={onChange}               
/>

<Input
type="text"
id="idreg"
label="IDReg"
className="inputIncNome"
name="idreg"
value={anexamentoregistrosData.idreg}
onChange={onChange}               
/>

<Input
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={anexamentoregistrosData.data}
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
 