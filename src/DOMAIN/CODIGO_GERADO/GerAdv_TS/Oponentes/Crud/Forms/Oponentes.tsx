"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IOponentes } from '../../Interfaces/interface.Oponentes';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import InputCnpj from '@/app/components/Inputs/InputCnpj'
import InputCpf from '@/app/components/Inputs/InputCpf'
import InputCep from '@/app/components/Inputs/InputCep'

interface OponentesFormProps {
    oponentesData: IOponentes;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const OponentesForm: React.FC<OponentesFormProps> = ({
    oponentesData,
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
            value={oponentesData.nome}
            onChange={onChange}
            required
          />

<Input
type="text"
id="empfuncao"
label="EMPFuncao"
className="inputIncNome"
name="empfuncao"
value={oponentesData.empfuncao}
onChange={onChange}               
/>

<Input
type="text"
id="ctpsnumero"
label="CTPSNumero"
className="inputIncNome"
name="ctpsnumero"
value={oponentesData.ctpsnumero}
onChange={onChange}               
/>

<Input
type="text"
id="site"
label="Site"
className="inputIncNome"
name="site"
value={oponentesData.site}
onChange={onChange}               
/>

<Input
type="text"
id="ctpsserie"
label="CTPSSerie"
className="inputIncNome"
name="ctpsserie"
value={oponentesData.ctpsserie}
onChange={onChange}               
/>

<Input
type="text"
id="adv"
label="Adv"
className="inputIncNome"
name="adv"
value={oponentesData.adv}
onChange={onChange}               
/>

<Input
type="text"
id="empcliente"
label="EMPCliente"
className="inputIncNome"
name="empcliente"
value={oponentesData.empcliente}
onChange={onChange}               
/>

<Input
type="text"
id="idrep"
label="IDRep"
className="inputIncNome"
name="idrep"
value={oponentesData.idrep}
onChange={onChange}               
/>

<Input
type="text"
id="pis"
label="PIS"
className="inputIncNome"
name="pis"
value={oponentesData.pis}
onChange={onChange}               
/>

<Input
type="text"
id="contato"
label="Contato"
className="inputIncNome"
name="contato"
value={oponentesData.contato}
onChange={onChange}               
/>

</div><div className="grid-container">        
<InputCnpj
type="text"
id="cnpj"
label="CNPJ"
className="inputIncNome"
name="cnpj"
value={oponentesData.cnpj}
onChange={onChange}               
/>

<Input
type="text"
id="rg"
label="RG"
className="inputIncNome"
name="rg"
value={oponentesData.rg}
onChange={onChange}               
/>

<Checkbox label="Juridica" name="juridica" checked={oponentesData.juridica} onChange={onChange} />
<Checkbox label="Tipo" name="tipo" checked={oponentesData.tipo} onChange={onChange} />
<Checkbox label="Sexo" name="sexo" checked={oponentesData.sexo} onChange={onChange} />
        
<InputCpf
type="text"
id="cpf"
label="CPF"
className="inputIncNome"
name="cpf"
value={oponentesData.cpf}
onChange={onChange}               
/>

<Input
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={oponentesData.endereco}
onChange={onChange}               
/>

<Input
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={oponentesData.fone}
onChange={onChange}               
/>

<Input
type="text"
id="fax"
label="Fax"
className="inputIncNome"
name="fax"
value={oponentesData.fax}
onChange={onChange}               
/>

<Input
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={oponentesData.cidade}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="bairro"
label="Bairro"
className="inputIncNome"
name="bairro"
value={oponentesData.bairro}
onChange={onChange}               
/>

<InputCep
type="text"
id="cep"
label="CEP"
className="inputIncNome"
name="cep"
value={oponentesData.cep}
onChange={onChange}               
/>

<Input
type="text"
id="inscest"
label="InscEst"
className="inputIncNome"
name="inscest"
value={oponentesData.inscest}
onChange={onChange}               
/>

<Input
type="text"
id="observacao"
label="Observacao"
className="inputIncNome"
name="observacao"
value={oponentesData.observacao}
onChange={onChange}               
/>

<Input
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={oponentesData.email}
onChange={onChange}               
/>

<Input
type="text"
id="class"
label="Class"
className="inputIncNome"
name="class"
value={oponentesData.class}
onChange={onChange}               
/>

<Checkbox label="Top" name="top" checked={oponentesData.top} onChange={onChange} />
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/gruposempresas${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?oponentes=${oponentesData.id}`)}>Grupos Empresas</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/oponentesreplegal${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?oponentes=${oponentesData.id}`)}>Oponentes Rep Legal</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/parteoponente${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?oponentes=${oponentesData.id}`)}>Parte Oponente</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/processos${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?oponentes=${oponentesData.id}`)}>Processos</div>

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
 