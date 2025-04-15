"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IClientesSocios } from '../../Interfaces/interface.ClientesSocios';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import InputCep from '@/app/components/Inputs/InputCep'
import InputCpf from '@/app/components/Inputs/InputCpf'
import InputCnpj from '@/app/components/Inputs/InputCnpj'

interface ClientesSociosFormProps {
    clientessociosData: IClientesSocios;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ClientesSociosForm: React.FC<ClientesSociosFormProps> = ({
    clientessociosData,
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

  if (clientessociosData.id === 0) {
    clientessociosData.cliente = getParamFromUrl("clientes");
  }
}
 const addValorCliente = (e: any) => {
                        if (e?.id>0)
                        clientessociosData.cliente = e.id;
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
            value={clientessociosData.nome}
            onChange={onChange}
            required
          />

          <Checkbox label="SomenteRepresentante" name="somenterepresentante" checked={clientessociosData.somenterepresentante} onChange={onChange} />
        
<Input
type="text"
id="idade"
label="Idade"
className="inputIncNome"
name="idade"
value={clientessociosData.idade}
onChange={onChange}               
/>

<Checkbox label="IsRepresentanteLegal" name="isrepresentantelegal" checked={clientessociosData.isrepresentantelegal} onChange={onChange} />
        
<Input
type="text"
id="qualificacao"
label="Qualificacao"
className="inputIncNome"
name="qualificacao"
value={clientessociosData.qualificacao}
onChange={onChange}               
/>

<Checkbox label="Sexo" name="sexo" checked={clientessociosData.sexo} onChange={onChange} />
        
<Input
type="text"
id="dtnasc"
label="DtNasc"
className="inputIncNome"
name="dtnasc"
value={clientessociosData.dtnasc}
onChange={onChange}               
/>

<Input
type="text"
id="site"
label="Site"
className="inputIncNome"
name="site"
value={clientessociosData.site}
onChange={onChange}               
/>

<Input
type="text"
id="representantelegal"
label="RepresentanteLegal"
className="inputIncNome"
name="representantelegal"
value={clientessociosData.representantelegal}
onChange={onChange}               
/>

            <ClientesComboBox
            name={'cliente'}
            value={clientessociosData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

</div><div className="grid-container">        
<Input
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={clientessociosData.endereco}
onChange={onChange}               
/>

<Input
type="text"
id="bairro"
label="Bairro"
className="inputIncNome"
name="bairro"
value={clientessociosData.bairro}
onChange={onChange}               
/>

<InputCep
type="text"
id="cep"
label="CEP"
className="inputIncNome"
name="cep"
value={clientessociosData.cep}
onChange={onChange}               
/>

<Input
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={clientessociosData.cidade}
onChange={onChange}               
/>

<Input
type="text"
id="rg"
label="RG"
className="inputIncNome"
name="rg"
value={clientessociosData.rg}
onChange={onChange}               
/>

<InputCpf
type="text"
id="cpf"
label="CPF"
className="inputIncNome"
name="cpf"
value={clientessociosData.cpf}
onChange={onChange}               
/>

<Input
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={clientessociosData.fone}
onChange={onChange}               
/>

<Input
type="text"
id="participacao"
label="Participacao"
className="inputIncNome"
name="participacao"
value={clientessociosData.participacao}
onChange={onChange}               
/>

<Input
type="text"
id="cargo"
label="Cargo"
className="inputIncNome"
name="cargo"
value={clientessociosData.cargo}
onChange={onChange}               
/>

<Input
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={clientessociosData.email}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="obs"
label="Obs"
className="inputIncNome"
name="obs"
value={clientessociosData.obs}
onChange={onChange}               
/>

<Input
type="text"
id="cnh"
label="CNH"
className="inputIncNome"
name="cnh"
value={clientessociosData.cnh}
onChange={onChange}               
/>

<Input
type="text"
id="datacontrato"
label="DataContrato"
className="inputIncNome"
name="datacontrato"
value={clientessociosData.datacontrato}
onChange={onChange}               
/>

<InputCnpj
type="text"
id="cnpj"
label="CNPJ"
className="inputIncNome"
name="cnpj"
value={clientessociosData.cnpj}
onChange={onChange}               
/>

<Input
type="text"
id="inscest"
label="InscEst"
className="inputIncNome"
name="inscest"
value={clientessociosData.inscest}
onChange={onChange}               
/>

<Input
type="text"
id="socioempresaadminnome"
label="SocioEmpresaAdminNome"
className="inputIncNome"
name="socioempresaadminnome"
value={clientessociosData.socioempresaadminnome}
onChange={onChange}               
/>

<Input
type="text"
id="enderecosocio"
label="EnderecoSocio"
className="inputIncNome"
name="enderecosocio"
value={clientessociosData.enderecosocio}
onChange={onChange}               
/>

<Input
type="text"
id="bairrosocio"
label="BairroSocio"
className="inputIncNome"
name="bairrosocio"
value={clientessociosData.bairrosocio}
onChange={onChange}               
/>

<Input
type="text"
id="cepsocio"
label="CEPSocio"
className="inputIncNome"
name="cepsocio"
value={clientessociosData.cepsocio}
onChange={onChange}               
/>

<Input
type="text"
id="cidadesocio"
label="CidadeSocio"
className="inputIncNome"
name="cidadesocio"
value={clientessociosData.cidadesocio}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="rgdataexp"
label="RGDataExp"
className="inputIncNome"
name="rgdataexp"
value={clientessociosData.rgdataexp}
onChange={onChange}               
/>

<Checkbox label="SocioEmpresaAdminSomente" name="socioempresaadminsomente" checked={clientessociosData.socioempresaadminsomente} onChange={onChange} />
<Checkbox label="Tipo" name="tipo" checked={clientessociosData.tipo} onChange={onChange} />
        
<Input
type="text"
id="fax"
label="Fax"
className="inputIncNome"
name="fax"
value={clientessociosData.fax}
onChange={onChange}               
/>

<Input
type="text"
id="class"
label="Class"
className="inputIncNome"
name="class"
value={clientessociosData.class}
onChange={onChange}               
/>

<Checkbox label="Ani" name="ani" checked={clientessociosData.ani} onChange={onChange} />
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/agendarecords${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?clientessocios=${clientessociosData.id}`)}>Agenda Records</div>

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
 