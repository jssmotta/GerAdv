// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IDadosProcuracao } from '@/app/GerAdv_TS/DadosProcuracao/Interfaces/interface.DadosProcuracao';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import InputName from '@/app/components/Inputs/InputName';

interface DadosProcuracaoFormProps {
    dadosprocuracaoData: IDadosProcuracao;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const DadosProcuracaoForm: React.FC<DadosProcuracaoFormProps> = ({
    dadosprocuracaoData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeClientes, setNomeClientes] = useState('');
            const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("clientes") > 0) {
  clientesApi
    .getById(getParamFromUrl("clientes"))
    .then((response) => {
      setNomeClientes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (dadosprocuracaoData.id === 0) {
    dadosprocuracaoData.cliente = getParamFromUrl("clientes");
  }
}
 const addValorCliente = (e: any) => {
                        if (e?.id>0)
                        dadosprocuracaoData.cliente = e.id;
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
      const formElement = document.getElementById('DadosProcuracaoForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`DadosProcuracaoForm-${dadosprocuracaoData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={dadosprocuracaoData} isSubmitting={isSubmitting} onClose={onClose} formId={`DadosProcuracaoForm-${dadosprocuracaoData.id}`} />

                <div className="grid-container">

            <ClientesComboBox
            name={'cliente'}
            value={dadosprocuracaoData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

<Input
type="text"
id="estadocivil"
label="EstadoCivil"
className="inputIncNome"
name="estadocivil"
value={dadosprocuracaoData.estadocivil}
onChange={onChange}               
/>

<Input
type="text"
id="nacionalidade"
label="Nacionalidade"
className="inputIncNome"
name="nacionalidade"
value={dadosprocuracaoData.nacionalidade}
onChange={onChange}               
/>

<Input
type="text"
id="profissao"
label="Profissao"
className="inputIncNome"
name="profissao"
value={dadosprocuracaoData.profissao}
onChange={onChange}               
/>

<Input
type="text"
id="ctps"
label="CTPS"
className="inputIncNome"
name="ctps"
value={dadosprocuracaoData.ctps}
onChange={onChange}               
/>

<Input
type="text"
id="pispasep"
label="PisPasep"
className="inputIncNome"
name="pispasep"
value={dadosprocuracaoData.pispasep}
onChange={onChange}               
/>

<Input
type="text"
id="remuneracao"
label="Remuneracao"
className="inputIncNome"
name="remuneracao"
value={dadosprocuracaoData.remuneracao}
onChange={onChange}               
/>

<Input
type="text"
id="objeto"
label="Objeto"
className="inputIncNome"
name="objeto"
value={dadosprocuracaoData.objeto}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        
    </>
     );
};
 