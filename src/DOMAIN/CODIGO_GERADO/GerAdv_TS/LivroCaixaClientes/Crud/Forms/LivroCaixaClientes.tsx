// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { ILivroCaixaClientes } from '@/app/GerAdv_TS/LivroCaixaClientes/Interfaces/interface.LivroCaixaClientes';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
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
    e.preventDefault();
    if (!isSubmitting) {
      setIsSubmitting(true);
      onSubmit(e);
    }
   };

  const onPressSalvar = (e: any) => {
    e.preventDefault();
    if (!isSubmitting) {
      const formElement = document.getElementById('LivroCaixaClientesForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`LivroCaixaClientesForm-${livrocaixaclientesData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={livrocaixaclientesData} isSubmitting={isSubmitting} onClose={onClose} formId={`LivroCaixaClientesForm-${livrocaixaclientesData.id}`} />

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
        
    </>
     );
};
 