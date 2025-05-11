// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IFuncionarios } from '@/app/GerAdv_TS/Funcionarios/Interfaces/interface.Funcionarios';
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

import CargosComboBox from '@/app/GerAdv_TS/Cargos/ComboBox/Cargos';
import { CargosApi } from '@/app/GerAdv_TS/Cargos/Apis/ApiCargos';
import InputName from '@/app/components/Inputs/InputName';
import InputSexo from '@/app/components/Inputs/InputSexo'
import InputCpf from '@/app/components/Inputs/InputCpf'
import InputInput from '@/app/components/Inputs/InputInput'
import InputCep from '@/app/components/Inputs/InputCep'
import InputDate from '@/app/components/Inputs/InputDate'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
import InputMemo from '@/app/components/Inputs/InputMemo'

interface FuncionariosFormProps {
    funcionariosData: IFuncionarios;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const FuncionariosForm: React.FC<FuncionariosFormProps> = ({
    funcionariosData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeCargos, setNomeCargos] = useState('');
            const cargosApi = new CargosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("cargos") > 0) {
  cargosApi
    .getById(getParamFromUrl("cargos"))
    .then((response) => {
      setNomeCargos(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (funcionariosData.id === 0) {
    funcionariosData.cargo = getParamFromUrl("cargos");
  }
}
 const addValorCargo = (e: any) => {
                        if (e?.id>0)
                        funcionariosData.cargo = e.id;
                      };

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
        console.error("Erro ao submeter formulário de Funcionarios:", error);
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
          target: document.getElementById(`FuncionariosForm-${funcionariosData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar Funcionarios diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-Funcionarios' : 'form-container form-container-Funcionarios'}>
       
            <form className='formInputCadInc' id={`FuncionariosForm-${funcionariosData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={funcionariosData} isSubmitting={isSubmitting} onClose={onClose} formId={`FuncionariosForm-${funcionariosData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="Nome"
            className="inputIncNome"
            name="nome"
            value={funcionariosData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
          />

<InputSexo
type="text"
id="sexo"
label="Sexo"
className="inputIncNome"
name="sexo"
value={funcionariosData.sexo}
onChange={onChange}               
/>

<InputCpf
type="text"
id="cpf"
label="CPF"
className="inputIncNome"
name="cpf"
value={funcionariosData.cpf}
onChange={onChange}               
/>

<InputInput
type="text"
id="rg"
label="RG"
className="inputIncNome"
name="rg"
value={funcionariosData.rg}
onChange={onChange}               
/>

<InputInput
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={funcionariosData.endereco}
onChange={onChange}               
/>

<InputInput
type="text"
id="bairro"
label="Bairro"
className="inputIncNome"
name="bairro"
value={funcionariosData.bairro}
onChange={onChange}               
/>

<InputInput
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={funcionariosData.cidade}
onChange={onChange}               
/>

<InputCep
type="text"
id="cep"
label="CEP"
className="inputIncNome"
name="cep"
value={funcionariosData.cep}
onChange={onChange}               
/>

<InputInput
type="text"
id="contato"
label="Contato"
className="inputIncNome"
name="contato"
value={funcionariosData.contato}
onChange={onChange}               
/>

<InputInput
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={funcionariosData.fone}
onChange={onChange}               
/>

</div><div className="grid-container">        
<InputInput
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={funcionariosData.email}
onChange={onChange}               
/>

<InputDate
type="text"
id="dtnasc"
label="DtNasc"
className="inputIncNome"
name="dtnasc"
value={funcionariosData.dtnasc}
onChange={(date: string) =>
    onChange({
      target: {
        name: 'dtnasc',
        value: date,
      },
    })
  }               
/>

<InputCheckbox label="LiberaAgenda" name="liberaagenda" checked={funcionariosData.liberaagenda} onChange={onChange} />
 
            <CargosComboBox
            name={'cargo'}
            value={funcionariosData.cargo}
            setValue={addValorCargo}
            label={'Cargos'}
            />

<InputMemo
type="text"
id="observacao"
label="Observacao"
className="inputIncNome"
name="observacao"
value={funcionariosData.observacao}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 