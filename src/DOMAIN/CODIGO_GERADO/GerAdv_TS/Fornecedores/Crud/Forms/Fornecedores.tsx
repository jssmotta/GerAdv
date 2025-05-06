// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IFornecedores } from '@/app/GerAdv_TS/Fornecedores/Interfaces/interface.Fornecedores';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import InputName from '@/app/components/Inputs/InputName';
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
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

  const onPressSalvar = (e: any) => {
    e.preventDefault();
    if (!isSubmitting) {
      const formElement = document.getElementById('FornecedoresForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container">
       
            <form id={`FornecedoresForm-${fornecedoresData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={fornecedoresData} isSubmitting={isSubmitting} onClose={onClose} formId={`FornecedoresForm-${fornecedoresData.id}`} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={fornecedoresData.nome}
            placeholder={`Digite nome fornecedores`}
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

<InputCheckbox label="Tipo" name="tipo" checked={fornecedoresData.tipo} onChange={onChange} />
<InputCheckbox label="Sexo" name="sexo" checked={fornecedoresData.sexo} onChange={onChange} />
        
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

                </div>               
            </form>
        </div>
        
    </>
     );
};
 