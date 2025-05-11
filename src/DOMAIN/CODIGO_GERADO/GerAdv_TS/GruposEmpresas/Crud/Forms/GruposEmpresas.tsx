// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IGruposEmpresas } from '@/app/GerAdv_TS/GruposEmpresas/Interfaces/interface.GruposEmpresas';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import OponentesComboBox from '@/app/GerAdv_TS/Oponentes/ComboBox/Oponentes';
import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import { OponentesApi } from '@/app/GerAdv_TS/Oponentes/Apis/ApiOponentes';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import InputDescription from '@/app/components/Inputs/InputDescription';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface GruposEmpresasFormProps {
    gruposempresasData: IGruposEmpresas;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const GruposEmpresasForm: React.FC<GruposEmpresasFormProps> = ({
    gruposempresasData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeOponentes, setNomeOponentes] = useState('');
            const oponentesApi = new OponentesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeClientes, setNomeClientes] = useState('');
            const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("oponentes") > 0) {
  oponentesApi
    .getById(getParamFromUrl("oponentes"))
    .then((response) => {
      setNomeOponentes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (gruposempresasData.id === 0) {
    gruposempresasData.oponente = getParamFromUrl("oponentes");
  }
}
 
if (getParamFromUrl("clientes") > 0) {
  clientesApi
    .getById(getParamFromUrl("clientes"))
    .then((response) => {
      setNomeClientes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (gruposempresasData.id === 0) {
    gruposempresasData.cliente = getParamFromUrl("clientes");
  }
}
 const addValorOponente = (e: any) => {
                        if (e?.id>0)
                        gruposempresasData.oponente = e.id;
                      };
 const addValorCliente = (e: any) => {
                        if (e?.id>0)
                        gruposempresasData.cliente = e.id;
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
        console.error("Erro ao submeter formulário de GruposEmpresas:", error);
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
          target: document.getElementById(`GruposEmpresasForm-${gruposempresasData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar GruposEmpresas diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-GruposEmpresas' : 'form-container5 form-container-GruposEmpresas'}>
       
            <form className='formInputCadInc' id={`GruposEmpresasForm-${gruposempresasData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={gruposempresasData} isSubmitting={isSubmitting} onClose={onClose} formId={`GruposEmpresasForm-${gruposempresasData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputDescription
            type="text"            
            id="descricao"
            label="grupos empresas"
            className="inputIncNome"
            name="descricao"
            value={gruposempresasData.descricao}
            placeholder={`Digite nome grupos empresas`}
            onChange={onChange}
            required
            disabled={gruposempresasData.id > 0}
          />

<InputInput
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={gruposempresasData.email}
onChange={onChange}               
/>

<InputCheckbox label="Inativo" name="inativo" checked={gruposempresasData.inativo} onChange={onChange} />
 
            <OponentesComboBox
            name={'oponente'}
            value={gruposempresasData.oponente}
            setValue={addValorOponente}
            label={'Oponentes'}
            />

<InputInput
type="text"
id="observacoes"
label="Observacoes"
className="inputIncNome"
name="observacoes"
value={gruposempresasData.observacoes}
onChange={onChange}               
/>

            <ClientesComboBox
            name={'cliente'}
            value={gruposempresasData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

<InputInput
type="text"
id="icone"
label="Icone"
className="inputIncNome"
name="icone"
value={gruposempresasData.icone}
onChange={onChange}               
/>

<InputCheckbox label="DespesaUnificada" name="despesaunificada" checked={gruposempresasData.despesaunificada} onChange={onChange} />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 