// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { ILivroCaixaClientes } from '@/app/GerAdv_TS/LivroCaixaClientes/Interfaces/interface.LivroCaixaClientes';
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

import LivroCaixaComboBox from '@/app/GerAdv_TS/LivroCaixa/ComboBox/LivroCaixa';
import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import { LivroCaixaApi } from '@/app/GerAdv_TS/LivroCaixa/Apis/ApiLivroCaixa';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import InputName from '@/app/components/Inputs/InputName';
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface LivroCaixaClientesFormProps {
    livrocaixaclientesData: ILivroCaixaClientes;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const LivroCaixaClientesForm: React.FC<LivroCaixaClientesFormProps> = ({
    livrocaixaclientesData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeLivroCaixa, setNomeLivroCaixa] = useState('');
            const livrocaixaApi = new LivroCaixaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeClientes, setNomeClientes] = useState('');
            const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("livrocaixa") > 0) {
  livrocaixaApi
    .getById(getParamFromUrl("livrocaixa"))
    .then((response) => {
      setNomeLivroCaixa(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

  if (livrocaixaclientesData.id === 0) {
    livrocaixaclientesData.livrocaixa = getParamFromUrl("livrocaixa");
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

  if (livrocaixaclientesData.id === 0) {
    livrocaixaclientesData.cliente = getParamFromUrl("clientes");
  }
}
 const addValorLivroCaixa = (e: any) => {
                        if (e?.id>0)
                        livrocaixaclientesData.livrocaixa = e.id;
                      };
 const addValorCliente = (e: any) => {
                        if (e?.id>0)
                        livrocaixaclientesData.cliente = e.id;
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
        console.error("Erro ao submeter formulário de LivroCaixaClientes:", error);
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
          target: document.getElementById(`LivroCaixaClientesForm-${livrocaixaclientesData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar LivroCaixaClientes diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-LivroCaixaClientes' : 'form-container5 form-container-LivroCaixaClientes'}>
       
            <form className='formInputCadInc' id={`LivroCaixaClientesForm-${livrocaixaclientesData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={livrocaixaclientesData} isSubmitting={isSubmitting} onClose={onClose} formId={`LivroCaixaClientesForm-${livrocaixaclientesData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

            <LivroCaixaComboBox
            name={'livrocaixa'}
            value={livrocaixaclientesData.livrocaixa}
            setValue={addValorLivroCaixa}
            label={'Livro Caixa'}
            />

            <ClientesComboBox
            name={'cliente'}
            value={livrocaixaclientesData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

<InputCheckbox label="Lancado" name="lancado" checked={livrocaixaclientesData.lancado} onChange={onChange} />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 