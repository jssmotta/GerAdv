"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IColaboradores } from '../../Interfaces/interface.Colaboradores';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import CargosComboBox from '@/app/GerAdv_TS/Cargos/ComboBox/Cargos';
import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import { CargosApi } from '@/app/GerAdv_TS/Cargos/Apis/ApiCargos';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import InputCpf from '@/app/components/Inputs/InputCpf'
import InputCep from '@/app/components/Inputs/InputCep'

interface ColaboradoresFormProps {
    colaboradoresData: IColaboradores;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ColaboradoresForm: React.FC<ColaboradoresFormProps> = ({
    colaboradoresData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeCargos, setNomeCargos] = useState('');
            const cargosApi = new CargosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeClientes, setNomeClientes] = useState('');
            const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("cargos") > 0) {
  cargosApi
    .getById(getParamFromUrl("cargos"))
    .then((response) => {
      setNomeCargos(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (colaboradoresData.id === 0) {
    colaboradoresData.cargo = getParamFromUrl("cargos");
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

  if (colaboradoresData.id === 0) {
    colaboradoresData.cliente = getParamFromUrl("clientes");
  }
}
 const addValorCargo = (e: any) => {
                        if (e?.id>0)
                        colaboradoresData.cargo = e.id;
                      };
 const addValorCliente = (e: any) => {
                        if (e?.id>0)
                        colaboradoresData.cliente = e.id;
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
  {nomeCargos && (<h2>{nomeCargos}</h2>)}
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
            value={colaboradoresData.nome}
            onChange={onChange}
            required
          />

            <CargosComboBox
            name={'cargo'}
            value={colaboradoresData.cargo}
            setValue={addValorCargo}
            label={'Cargos'}
            />

            <ClientesComboBox
            name={'cliente'}
            value={colaboradoresData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

<Checkbox label="Sexo" name="sexo" checked={colaboradoresData.sexo} onChange={onChange} />
        
<InputCpf
type="text"
id="cpf"
label="CPF"
className="inputIncNome"
name="cpf"
value={colaboradoresData.cpf}
onChange={onChange}               
/>

<Input
type="text"
id="rg"
label="RG"
className="inputIncNome"
name="rg"
value={colaboradoresData.rg}
onChange={onChange}               
/>

<Input
type="text"
id="dtnasc"
label="DtNasc"
className="inputIncNome"
name="dtnasc"
value={colaboradoresData.dtnasc}
onChange={onChange}               
/>

<Input
type="text"
id="idade"
label="Idade"
className="inputIncNome"
name="idade"
value={colaboradoresData.idade}
onChange={onChange}               
/>

<Input
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={colaboradoresData.endereco}
onChange={onChange}               
/>

<Input
type="text"
id="bairro"
label="Bairro"
className="inputIncNome"
name="bairro"
value={colaboradoresData.bairro}
onChange={onChange}               
/>

</div><div className="grid-container">        
<InputCep
type="text"
id="cep"
label="CEP"
className="inputIncNome"
name="cep"
value={colaboradoresData.cep}
onChange={onChange}               
/>

<Input
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={colaboradoresData.cidade}
onChange={onChange}               
/>

<Input
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={colaboradoresData.fone}
onChange={onChange}               
/>

<Input
type="text"
id="observacao"
label="Observacao"
className="inputIncNome"
name="observacao"
value={colaboradoresData.observacao}
onChange={onChange}               
/>

<Input
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={colaboradoresData.email}
onChange={onChange}               
/>

<Input
type="text"
id="cnh"
label="CNH"
className="inputIncNome"
name="cnh"
value={colaboradoresData.cnh}
onChange={onChange}               
/>

<Input
type="text"
id="class"
label="Class"
className="inputIncNome"
name="class"
value={colaboradoresData.class}
onChange={onChange}               
/>

<Checkbox label="Ani" name="ani" checked={colaboradoresData.ani} onChange={onChange} />
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/agendarecords${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?colaboradores=${colaboradoresData.id}`)}>Agenda Records</div>

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
 