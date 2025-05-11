// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IGruposEmpresasCli } from '@/app/GerAdv_TS/GruposEmpresasCli/Interfaces/interface.GruposEmpresasCli';
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

import GruposEmpresasComboBox from '@/app/GerAdv_TS/GruposEmpresas/ComboBox/GruposEmpresas';
import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import { GruposEmpresasApi } from '@/app/GerAdv_TS/GruposEmpresas/Apis/ApiGruposEmpresas';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import InputName from '@/app/components/Inputs/InputName';
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface GruposEmpresasCliFormProps {
    gruposempresascliData: IGruposEmpresasCli;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const GruposEmpresasCliForm: React.FC<GruposEmpresasCliFormProps> = ({
    gruposempresascliData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeGruposEmpresas, setNomeGruposEmpresas] = useState('');
            const gruposempresasApi = new GruposEmpresasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeClientes, setNomeClientes] = useState('');
            const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("gruposempresas") > 0) {
  gruposempresasApi
    .getById(getParamFromUrl("gruposempresas"))
    .then((response) => {
      setNomeGruposEmpresas(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

  if (gruposempresascliData.id === 0) {
    gruposempresascliData.grupo = getParamFromUrl("gruposempresas");
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

  if (gruposempresascliData.id === 0) {
    gruposempresascliData.cliente = getParamFromUrl("clientes");
  }
}
 const addValorGrupo = (e: any) => {
                        if (e?.id>0)
                        gruposempresascliData.grupo = e.id;
                      };
 const addValorCliente = (e: any) => {
                        if (e?.id>0)
                        gruposempresascliData.cliente = e.id;
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
        console.error("Erro ao submeter formulário de GruposEmpresasCli:", error);
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
          target: document.getElementById(`GruposEmpresasCliForm-${gruposempresascliData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar GruposEmpresasCli diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-GruposEmpresasCli' : 'form-container5 form-container-GruposEmpresasCli'}>
       
            <form className='formInputCadInc' id={`GruposEmpresasCliForm-${gruposempresascliData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={gruposempresascliData} isSubmitting={isSubmitting} onClose={onClose} formId={`GruposEmpresasCliForm-${gruposempresascliData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

            <GruposEmpresasComboBox
            name={'grupo'}
            value={gruposempresascliData.grupo}
            setValue={addValorGrupo}
            label={'Grupos Empresas'}
            />

            <ClientesComboBox
            name={'cliente'}
            value={gruposempresascliData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

<InputCheckbox label="Oculto" name="oculto" checked={gruposempresascliData.oculto} onChange={onChange} />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 