// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IDadosProcuracao } from '@/app/GerAdv_TS/DadosProcuracao/Interfaces/interface.DadosProcuracao';
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

import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'

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
  const isMobile = useIsMobile();
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
        console.error("Erro ao submeter formulário de DadosProcuracao:", error);
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
          target: document.getElementById(`DadosProcuracaoForm-${dadosprocuracaoData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar DadosProcuracao diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-DadosProcuracao' : 'form-container5 form-container-DadosProcuracao'}>
       
            <form className='formInputCadInc' id={`DadosProcuracaoForm-${dadosprocuracaoData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={dadosprocuracaoData} isSubmitting={isSubmitting} onClose={onClose} formId={`DadosProcuracaoForm-${dadosprocuracaoData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

            <ClientesComboBox
            name={'cliente'}
            value={dadosprocuracaoData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

<InputInput
type="text"
id="estadocivil"
label="EstadoCivil"
className="inputIncNome"
name="estadocivil"
value={dadosprocuracaoData.estadocivil}
onChange={onChange}               
/>

<InputInput
type="text"
id="nacionalidade"
label="Nacionalidade"
className="inputIncNome"
name="nacionalidade"
value={dadosprocuracaoData.nacionalidade}
onChange={onChange}               
/>

<InputInput
type="text"
id="profissao"
label="Profissao"
className="inputIncNome"
name="profissao"
value={dadosprocuracaoData.profissao}
onChange={onChange}               
/>

<InputInput
type="text"
id="ctps"
label="CTPS"
className="inputIncNome"
name="ctps"
value={dadosprocuracaoData.ctps}
onChange={onChange}               
/>

<InputInput
type="text"
id="pispasep"
label="PisPasep"
className="inputIncNome"
name="pispasep"
value={dadosprocuracaoData.pispasep}
onChange={onChange}               
/>

<InputInput
type="text"
id="remuneracao"
label="Remuneracao"
className="inputIncNome"
name="remuneracao"
value={dadosprocuracaoData.remuneracao}
onChange={onChange}               
/>

<InputInput
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
        <div className="form-spacer"></div>
        
    </>
     );
};
 