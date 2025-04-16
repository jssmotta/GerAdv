"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IOperadores } from '../../Interfaces/interface.Operadores';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';

interface OperadoresFormProps {
    operadoresData: IOperadores;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const OperadoresForm: React.FC<OperadoresFormProps> = ({
    operadoresData,
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
      setNomeClientes(response.data.ome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (operadoresData.id === 0) {
    operadoresData.cliente = getParamFromUrl("clientes");
  }
}
 const addValorCliente = (e: any) => {
                        if (e?.id>0)
                        operadoresData.cliente = e.id;
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

    <Input
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={operadoresData.nome}
            onChange={onChange}
            required
          />

          <Checkbox label="Enviado" name="enviado" checked={operadoresData.enviado} onChange={onChange} />
<Checkbox label="Casa" name="casa" checked={operadoresData.casa} onChange={onChange} />
        
<Input
type="text"
id="casaid"
label="CasaID"
className="inputIncNome"
name="casaid"
value={operadoresData.casaid}
onChange={onChange}               
/>

<Input
type="text"
id="casacodigo"
label="CasaCodigo"
className="inputIncNome"
name="casacodigo"
value={operadoresData.casacodigo}
onChange={onChange}               
/>

<Checkbox label="IsNovo" name="isnovo" checked={operadoresData.isnovo} onChange={onChange} />
 
            <ClientesComboBox
            name={'cliente'}
            value={operadoresData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

<Input
type="text"
id="grupo"
label="Grupo"
className="inputIncNome"
name="grupo"
value={operadoresData.grupo}
onChange={onChange}               
/>

<Input
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={operadoresData.email}
onChange={onChange}               
/>

<Input
autoComplete="off"
type="password"
id="senha"
label="Senha"
className="inputIncNome"
name="senha"
value={operadoresData.senha}
onChange={onChange}               
/>

</div><div className="grid-container"><Checkbox label="Ativado" name="ativado" checked={operadoresData.ativado} onChange={onChange} />
<Checkbox label="AtualizarSenha" name="atualizarsenha" checked={operadoresData.atualizarsenha} onChange={onChange} />
        
<Input
autoComplete="off"
type="password"
id="senha256"
label="Senha256"
className="inputIncNome"
name="senha256"
value={operadoresData.senha256}
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
 