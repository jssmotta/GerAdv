"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IOutrasPartesCliente } from '../../Interfaces/interface.OutrasPartesCliente';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import InputCpf from '@/app/components/Inputs/InputCpf'
import InputCnpj from '@/app/components/Inputs/InputCnpj'
import InputCep from '@/app/components/Inputs/InputCep'

interface OutrasPartesClienteFormProps {
    outraspartesclienteData: IOutrasPartesCliente;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const OutrasPartesClienteForm: React.FC<OutrasPartesClienteFormProps> = ({
    outraspartesclienteData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  
  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (!isSubmitting) {
      setIsSubmitting(true);
      onSubmit(e);
    }
   };

  return (
  <>
  
    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

    <Input
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={outraspartesclienteData.nome}
            onChange={onChange}
            required
          />

          <Checkbox label="Terceirizado" name="terceirizado" checked={outraspartesclienteData.terceirizado} onChange={onChange} />
        
<Input
type="text"
id="clienteprincipal"
label="ClientePrincipal"
className="inputIncNome"
name="clienteprincipal"
value={outraspartesclienteData.clienteprincipal}
onChange={onChange}               
/>

<Checkbox label="Tipo" name="tipo" checked={outraspartesclienteData.tipo} onChange={onChange} />
<Checkbox label="Sexo" name="sexo" checked={outraspartesclienteData.sexo} onChange={onChange} />
        
<Input
type="text"
id="dtnasc"
label="DtNasc"
className="inputIncNome"
name="dtnasc"
value={outraspartesclienteData.dtnasc}
onChange={onChange}               
/>

<InputCpf
type="text"
id="cpf"
label="CPF"
className="inputIncNome"
name="cpf"
value={outraspartesclienteData.cpf}
onChange={onChange}               
/>

<Input
type="text"
id="rg"
label="RG"
className="inputIncNome"
name="rg"
value={outraspartesclienteData.rg}
onChange={onChange}               
/>

<InputCnpj
type="text"
id="cnpj"
label="CNPJ"
className="inputIncNome"
name="cnpj"
value={outraspartesclienteData.cnpj}
onChange={onChange}               
/>

<Input
type="text"
id="inscest"
label="InscEst"
className="inputIncNome"
name="inscest"
value={outraspartesclienteData.inscest}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="nomefantasia"
label="NomeFantasia"
className="inputIncNome"
name="nomefantasia"
value={outraspartesclienteData.nomefantasia}
onChange={onChange}               
/>

<Input
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={outraspartesclienteData.endereco}
onChange={onChange}               
/>

<Input
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={outraspartesclienteData.cidade}
onChange={onChange}               
/>

<InputCep
type="text"
id="cep"
label="CEP"
className="inputIncNome"
name="cep"
value={outraspartesclienteData.cep}
onChange={onChange}               
/>

<Input
type="text"
id="bairro"
label="Bairro"
className="inputIncNome"
name="bairro"
value={outraspartesclienteData.bairro}
onChange={onChange}               
/>

<Input
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={outraspartesclienteData.fone}
onChange={onChange}               
/>

<Input
type="text"
id="fax"
label="Fax"
className="inputIncNome"
name="fax"
value={outraspartesclienteData.fax}
onChange={onChange}               
/>

<Input
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={outraspartesclienteData.email}
onChange={onChange}               
/>

<Input
type="text"
id="site"
label="Site"
className="inputIncNome"
name="site"
value={outraspartesclienteData.site}
onChange={onChange}               
/>

<Input
type="text"
id="class"
label="Class"
className="inputIncNome"
name="class"
value={outraspartesclienteData.class}
onChange={onChange}               
/>

</div><div className="grid-container"><Checkbox label="Ani" name="ani" checked={outraspartesclienteData.ani} onChange={onChange} />
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/parteclienteoutras${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?outraspartescliente=${outraspartesclienteData.id}`)}>Parte Cliente Outras</div>

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
 