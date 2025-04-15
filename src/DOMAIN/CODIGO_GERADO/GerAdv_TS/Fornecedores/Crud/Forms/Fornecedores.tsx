"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IFornecedores } from '../../Interfaces/interface.Fornecedores';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import InputCnpj from '@/app/components/Inputs/InputCnpj'
import InputCpf from '@/app/components/Inputs/InputCpf'
import InputCep from '@/app/components/Inputs/InputCep'

interface FornecedoresFormProps {
    fornecedoresData: IFornecedores;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const FornecedoresForm: React.FC<FornecedoresFormProps> = ({
    fornecedoresData,
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
            value={fornecedoresData.nome}
            onChange={onChange}
            required
          />

<Input
type="text"
id="grupo"
label="Grupo"
className="inputIncNome"
name="grupo"
value={fornecedoresData.grupo}
onChange={onChange}               
/>

<Input
type="text"
id="subgrupo"
label="SubGrupo"
className="inputIncNome"
name="subgrupo"
value={fornecedoresData.subgrupo}
onChange={onChange}               
/>

<Checkbox label="Tipo" name="tipo" checked={fornecedoresData.tipo} onChange={onChange} />
<Checkbox label="Sexo" name="sexo" checked={fornecedoresData.sexo} onChange={onChange} />
        
<InputCnpj
type="text"
id="cnpj"
label="CNPJ"
className="inputIncNome"
name="cnpj"
value={fornecedoresData.cnpj}
onChange={onChange}               
/>

<Input
type="text"
id="inscest"
label="InscEst"
className="inputIncNome"
name="inscest"
value={fornecedoresData.inscest}
onChange={onChange}               
/>

<InputCpf
type="text"
id="cpf"
label="CPF"
className="inputIncNome"
name="cpf"
value={fornecedoresData.cpf}
onChange={onChange}               
/>

<Input
type="text"
id="rg"
label="RG"
className="inputIncNome"
name="rg"
value={fornecedoresData.rg}
onChange={onChange}               
/>

<Input
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={fornecedoresData.endereco}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="bairro"
label="Bairro"
className="inputIncNome"
name="bairro"
value={fornecedoresData.bairro}
onChange={onChange}               
/>

<InputCep
type="text"
id="cep"
label="CEP"
className="inputIncNome"
name="cep"
value={fornecedoresData.cep}
onChange={onChange}               
/>

<Input
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={fornecedoresData.cidade}
onChange={onChange}               
/>

<Input
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={fornecedoresData.fone}
onChange={onChange}               
/>

<Input
type="text"
id="fax"
label="Fax"
className="inputIncNome"
name="fax"
value={fornecedoresData.fax}
onChange={onChange}               
/>

<Input
type="email"
id="email"
label="Email"
className="inputIncNome"
name="email"
value={fornecedoresData.email}
onChange={onChange}               
/>

<Input
type="text"
id="site"
label="Site"
className="inputIncNome"
name="site"
value={fornecedoresData.site}
onChange={onChange}               
/>

<Input
type="text"
id="obs"
label="Obs"
className="inputIncNome"
name="obs"
value={fornecedoresData.obs}
onChange={onChange}               
/>

<Input
type="text"
id="produtos"
label="Produtos"
className="inputIncNome"
name="produtos"
value={fornecedoresData.produtos}
onChange={onChange}               
/>

<Input
type="text"
id="contatos"
label="Contatos"
className="inputIncNome"
name="contatos"
value={fornecedoresData.contatos}
onChange={onChange}               
/>

							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/bensmateriais${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?fornecedores=${fornecedoresData.id}`)}>Bens Materiais</div>

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
 