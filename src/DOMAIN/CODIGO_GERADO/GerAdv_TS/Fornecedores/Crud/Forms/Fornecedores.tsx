// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IFornecedores } from '@/app/GerAdv_TS/Fornecedores/Interfaces/interface.Fornecedores';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
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
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  
    const onConfirm = (e: React.FormEvent) => {
    // Importante: prevenir comportamento padrão e propagação
    e.preventDefault();
    if (e.stopPropagation) e.stopPropagation();
    
    // Evitar múltiplos envios
    if (!isSubmitting) {
      setIsSubmitting(true);
      
      // Chamar onSubmit com o evento
      try {
        onSubmit(e);
      } catch (error) {
        console.error("Erro ao submeter formulário de Fornecedores:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  // Handler para submissão direta via ButtonsCrud
  const handleDirectSave = () => {
    if (!isSubmitting) {
      setIsSubmitting(true);
      
      try {
        // Criar um evento sintético básico para manter compatibilidade
        const syntheticEvent = {
          preventDefault: () => { },
          target: document.getElementById(`FornecedoresForm-${fornecedoresData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar Fornecedores diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-Fornecedores' : 'form-container form-container-Fornecedores'}>
       
            <form className='formInputCadInc' id={`FornecedoresForm-${fornecedoresData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={fornecedoresData} isSubmitting={isSubmitting} onClose={onClose} formId={`FornecedoresForm-${fornecedoresData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="Nome"
            className="inputIncNome"
            name="nome"
            value={fornecedoresData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
          />

<InputInput
type="text"
id="grupo"
label="Grupo"
className="inputIncNome"
name="grupo"
value={fornecedoresData.grupo}
onChange={onChange}               
/>

<InputInput
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

<InputInput
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

<InputInput
type="text"
id="rg"
label="RG"
className="inputIncNome"
name="rg"
value={fornecedoresData.rg}
onChange={onChange}               
/>

<InputInput
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={fornecedoresData.endereco}
onChange={onChange}               
/>

</div><div className="grid-container">        
<InputInput
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

<InputInput
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={fornecedoresData.cidade}
onChange={onChange}               
/>

<InputInput
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={fornecedoresData.fone}
onChange={onChange}               
/>

<InputInput
type="text"
id="fax"
label="Fax"
className="inputIncNome"
name="fax"
value={fornecedoresData.fax}
onChange={onChange}               
/>

<InputInput
type="email"
id="email"
label="Email"
className="inputIncNome"
name="email"
value={fornecedoresData.email}
onChange={onChange}               
/>

<InputInput
type="text"
id="site"
label="Site"
className="inputIncNome"
name="site"
value={fornecedoresData.site}
onChange={onChange}               
/>

<InputInput
type="text"
id="obs"
label="Obs"
className="inputIncNome"
name="obs"
value={fornecedoresData.obs}
onChange={onChange}               
/>

<InputInput
type="text"
id="produtos"
label="Produtos"
className="inputIncNome"
name="produtos"
value={fornecedoresData.produtos}
onChange={onChange}               
/>

<InputInput
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
        <div className="form-spacer"></div>
        
    </>
     );
};
 