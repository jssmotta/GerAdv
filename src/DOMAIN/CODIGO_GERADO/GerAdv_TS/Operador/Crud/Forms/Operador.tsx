// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IOperador } from '@/app/GerAdv_TS/Operador/Interfaces/interface.Operador';
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

interface OperadorFormProps {
    operadorData: IOperador;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const OperadorForm: React.FC<OperadorFormProps> = ({
    operadorData,
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
        console.error("Erro ao submeter formulário de Operador:", error);
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
          target: document.getElementById(`OperadorForm-${operadorData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar Operador diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-Operador' : 'form-container form-container-Operador'}>
       
            <form className='formInputCadInc' id={`OperadorForm-${operadorData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={operadorData} isSubmitting={isSubmitting} onClose={onClose} formId={`OperadorForm-${operadorData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="Nome"
            className="inputIncNome"
            name="nome"
            value={operadorData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
          />

<InputInput
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={operadorData.email}
onChange={onChange}               
/>

<InputInput
type="text"
id="pasta"
label="Pasta"
className="inputIncNome"
name="pasta"
value={operadorData.pasta}
onChange={onChange}               
/>

<InputCheckbox label="Telefonista" name="telefonista" checked={operadorData.telefonista} onChange={onChange} />
<InputCheckbox label="Master" name="master" checked={operadorData.master} onChange={onChange} />
        
<InputInput
type="text"
id="nick"
label="Nick"
className="inputIncNome"
name="nick"
value={operadorData.nick}
onChange={onChange}               
/>

<InputCheckbox label="Excluido" name="excluido" checked={operadorData.excluido} onChange={onChange} />
<InputCheckbox label="Situacao" name="situacao" checked={operadorData.situacao} onChange={onChange} />
        
<InputInput
type="text"
id="minhadescricao"
label="MinhaDescricao"
className="inputIncNome"
name="minhadescricao"
value={operadorData.minhadescricao}
onChange={onChange}               
/>

<InputInput
type="email"
id="emailnet"
label="EMailNet"
className="inputIncNome"
name="emailnet"
value={operadorData.emailnet}
onChange={onChange}               
/>

</div><div className="grid-container"><InputCheckbox label="OnLine" name="online" checked={operadorData.online} onChange={onChange} />
<InputCheckbox label="SysOp" name="sysop" checked={operadorData.sysop} onChange={onChange} />
<InputCheckbox label="IsFinanceiro" name="isfinanceiro" checked={operadorData.isfinanceiro} onChange={onChange} />
<InputCheckbox label="Top" name="top" checked={operadorData.top} onChange={onChange} />
<InputCheckbox label="Sexo" name="sexo" checked={operadorData.sexo} onChange={onChange} />
<InputCheckbox label="Basico" name="basico" checked={operadorData.basico} onChange={onChange} />
<InputCheckbox label="Externo" name="externo" checked={operadorData.externo} onChange={onChange} />
        
<InputInput
autoComplete="off"
type="password"
id="senha256"
label="Senha256"
className="inputIncNome"
name="senha256"
value={operadorData.senha256}
onChange={onChange}               
/>

<InputCheckbox label="EMailConfirmado" name="emailconfirmado" checked={operadorData.emailconfirmado} onChange={onChange} />
        
<InputInput
type="text"
id="datalimitereset"
label="DataLimiteReset"
className="inputIncNome"
name="datalimitereset"
value={operadorData.datalimitereset}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 