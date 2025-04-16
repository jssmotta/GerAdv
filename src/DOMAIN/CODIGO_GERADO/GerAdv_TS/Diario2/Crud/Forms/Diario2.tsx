"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IDiario2 } from '../../Interfaces/interface.Diario2';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';

interface Diario2FormProps {
    diario2Data: IDiario2;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const Diario2Form: React.FC<Diario2FormProps> = ({
    diario2Data,
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
const [nomeClientes, setNomeClientes] = useState('');
            const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("operador") > 0) {
  operadorApi
    .getById(getParamFromUrl("operador"))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (diario2Data.id === 0) {
    diario2Data.operador = getParamFromUrl("operador");
  }
}
 
if (getParamFromUrl("clientes") > 0) {
  clientesApi
    .getById(getParamFromUrl("clientes"))
    .then((response) => {
      setNomeClientes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (diario2Data.id === 0) {
    diario2Data.cliente = getParamFromUrl("clientes");
  }
}
 const addValorOperador = (e: any) => {
                        if (e?.id>0)
                        diario2Data.operador = e.id;
                      };
 const addValorCliente = (e: any) => {
                        if (e?.id>0)
                        diario2Data.cliente = e.id;
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
{nomeClientes && (<h2>{nomeClientes}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

    <Input
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={diario2Data.nome}
            onChange={onChange}
            required
          />

<Input
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={diario2Data.data}
onChange={onChange}               
/>

<Input
type="text"
id="hora"
label="Hora"
className="inputIncNome"
name="hora"
value={diario2Data.hora}
onChange={onChange}               
/>

            <OperadorComboBox
            name={'operador'}
            value={diario2Data.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />

<Input
type="text"
id="ocorrencia"
label="Ocorrencia"
className="inputIncNome"
name="ocorrencia"
value={diario2Data.ocorrencia}
onChange={onChange}               
/>

            <ClientesComboBox
            name={'cliente'}
            value={diario2Data.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
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
 