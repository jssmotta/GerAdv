// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IOperador } from '@/app/GerAdv_TS/Operador/Interfaces/interface.Operador';
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
      const formElement = document.getElementById('OperadorForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container">
       
            <form id={`OperadorForm-${operadorData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={operadorData} isSubmitting={isSubmitting} onClose={onClose} formId={`OperadorForm-${operadorData.id}`} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={operadorData.nome}
            placeholder={`Digite nome operador`}
            onChange={onChange}
            required
          />

<Input
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={operadorData.email}
onChange={onChange}               
/>

<Input
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
        
<Input
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
        
<Input
type="text"
id="minhadescricao"
label="MinhaDescricao"
className="inputIncNome"
name="minhadescricao"
value={operadorData.minhadescricao}
onChange={onChange}               
/>

<Input
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
        
<Input
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
        
<Input
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
        
    </>
     );
};
 