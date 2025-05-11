// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IBensMateriais } from '@/app/GerAdv_TS/BensMateriais/Interfaces/interface.BensMateriais';
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

import BensClassificacaoComboBox from '@/app/GerAdv_TS/BensClassificacao/ComboBox/BensClassificacao';
import FornecedoresComboBox from '@/app/GerAdv_TS/Fornecedores/ComboBox/Fornecedores';
import { BensClassificacaoApi } from '@/app/GerAdv_TS/BensClassificacao/Apis/ApiBensClassificacao';
import { FornecedoresApi } from '@/app/GerAdv_TS/Fornecedores/Apis/ApiFornecedores';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface BensMateriaisFormProps {
    bensmateriaisData: IBensMateriais;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const BensMateriaisForm: React.FC<BensMateriaisFormProps> = ({
    bensmateriaisData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeBensClassificacao, setNomeBensClassificacao] = useState('');
            const bensclassificacaoApi = new BensClassificacaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeFornecedores, setNomeFornecedores] = useState('');
            const fornecedoresApi = new FornecedoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("bensclassificacao") > 0) {
  bensclassificacaoApi
    .getById(getParamFromUrl("bensclassificacao"))
    .then((response) => {
      setNomeBensClassificacao(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (bensmateriaisData.id === 0) {
    bensmateriaisData.bensclassificacao = getParamFromUrl("bensclassificacao");
  }
}
 
if (getParamFromUrl("fornecedores") > 0) {
  fornecedoresApi
    .getById(getParamFromUrl("fornecedores"))
    .then((response) => {
      setNomeFornecedores(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (bensmateriaisData.id === 0) {
    bensmateriaisData.fornecedor = getParamFromUrl("fornecedores");
  }
}
 const addValorBensClassificacao = (e: any) => {
                        if (e?.id>0)
                        bensmateriaisData.bensclassificacao = e.id;
                      };
 const addValorFornecedor = (e: any) => {
                        if (e?.id>0)
                        bensmateriaisData.fornecedor = e.id;
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
        console.error("Erro ao submeter formulário de BensMateriais:", error);
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
          target: document.getElementById(`BensMateriaisForm-${bensmateriaisData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar BensMateriais diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-BensMateriais' : 'form-container form-container-BensMateriais'}>
       
            <form className='formInputCadInc' id={`BensMateriaisForm-${bensmateriaisData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={bensmateriaisData} isSubmitting={isSubmitting} onClose={onClose} formId={`BensMateriaisForm-${bensmateriaisData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="Nome"
            className="inputIncNome"
            name="nome"
            value={bensmateriaisData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
          />

            <BensClassificacaoComboBox
            name={'bensclassificacao'}
            value={bensmateriaisData.bensclassificacao}
            setValue={addValorBensClassificacao}
            label={'Bens Classificacao'}
            />

<InputInput
type="text"
id="datacompra"
label="DataCompra"
className="inputIncNome"
name="datacompra"
value={bensmateriaisData.datacompra}
onChange={onChange}               
/>

<InputInput
type="text"
id="datafimdagarantia"
label="DataFimDaGarantia"
className="inputIncNome"
name="datafimdagarantia"
value={bensmateriaisData.datafimdagarantia}
onChange={onChange}               
/>

<InputInput
type="text"
id="nfnro"
label="NFNRO"
className="inputIncNome"
name="nfnro"
value={bensmateriaisData.nfnro}
onChange={onChange}               
/>

            <FornecedoresComboBox
            name={'fornecedor'}
            value={bensmateriaisData.fornecedor}
            setValue={addValorFornecedor}
            label={'Fornecedores'}
            />

<InputInput
type="text"
id="valorbem"
label="ValorBem"
className="inputIncNome"
name="valorbem"
value={bensmateriaisData.valorbem}
onChange={onChange}               
/>

<InputInput
type="text"
id="nroserieproduto"
label="NroSerieProduto"
className="inputIncNome"
name="nroserieproduto"
value={bensmateriaisData.nroserieproduto}
onChange={onChange}               
/>

<InputInput
type="text"
id="comprador"
label="Comprador"
className="inputIncNome"
name="comprador"
value={bensmateriaisData.comprador}
onChange={onChange}               
/>

<InputInput
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={bensmateriaisData.cidade}
onChange={onChange}               
/>

</div><div className="grid-container"><InputCheckbox label="GarantiaLoja" name="garantialoja" checked={bensmateriaisData.garantialoja} onChange={onChange} />
        
<InputInput
type="text"
id="dataterminodagarantiadaloja"
label="DataTerminoDaGarantiaDaLoja"
className="inputIncNome"
name="dataterminodagarantiadaloja"
value={bensmateriaisData.dataterminodagarantiadaloja}
onChange={onChange}               
/>

<InputInput
type="text"
id="observacoes"
label="Observacoes"
className="inputIncNome"
name="observacoes"
value={bensmateriaisData.observacoes}
onChange={onChange}               
/>

<InputInput
type="text"
id="nomevendedor"
label="NomeVendedor"
className="inputIncNome"
name="nomevendedor"
value={bensmateriaisData.nomevendedor}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 