// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IOperadores } from '@/app/GerAdv_TS/Operadores/Interfaces/interface.Operadores';
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

import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import InputName from '@/app/components/Inputs/InputName';
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
import InputInput from '@/app/components/Inputs/InputInput'

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
  const isMobile = useIsMobile();
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
        console.error("Erro ao submeter formulário de Operadores:", error);
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
          target: document.getElementById(`OperadoresForm-${operadoresData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar Operadores diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-Operadores' : 'form-container form-container-Operadores'}>
       
            <form className='formInputCadInc' id={`OperadoresForm-${operadoresData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={operadoresData} isSubmitting={isSubmitting} onClose={onClose} formId={`OperadoresForm-${operadoresData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="Nome"
            className="inputIncNome"
            name="nome"
            value={operadoresData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
          />

                <InputCheckbox label="Enviado" name="enviado" checked={operadoresData.enviado} onChange={onChange} />
<InputCheckbox label="Casa" name="casa" checked={operadoresData.casa} onChange={onChange} />
        
<InputInput
type="text"
id="casaid"
label="CasaID"
className="inputIncNome"
name="casaid"
value={operadoresData.casaid}
onChange={onChange}               
/>

<InputInput
type="text"
id="casacodigo"
label="CasaCodigo"
className="inputIncNome"
name="casacodigo"
value={operadoresData.casacodigo}
onChange={onChange}               
/>

<InputCheckbox label="IsNovo" name="isnovo" checked={operadoresData.isnovo} onChange={onChange} />
 
            <ClientesComboBox
            name={'cliente'}
            value={operadoresData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

<InputInput
type="text"
id="grupo"
label="Grupo"
className="inputIncNome"
name="grupo"
value={operadoresData.grupo}
onChange={onChange}               
/>

<InputInput
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={operadoresData.email}
onChange={onChange}               
/>

<InputInput
autoComplete="off"
type="password"
id="senha"
label="Senha"
className="inputIncNome"
name="senha"
value={operadoresData.senha}
onChange={onChange}               
/>

</div><div className="grid-container"><InputCheckbox label="Ativado" name="ativado" checked={operadoresData.ativado} onChange={onChange} />
<InputCheckbox label="AtualizarSenha" name="atualizarsenha" checked={operadoresData.atualizarsenha} onChange={onChange} />
        
<InputInput
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
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 