"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IBensMateriais } from '../../Interfaces/interface.BensMateriais';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import BensClassificacaoComboBox from '@/app/GerAdv_TS/BensClassificacao/ComboBox/BensClassificacao';
import FornecedoresComboBox from '@/app/GerAdv_TS/Fornecedores/ComboBox/Fornecedores';
import { BensClassificacaoApi } from '@/app/GerAdv_TS/BensClassificacao/Apis/ApiBensClassificacao';
import { FornecedoresApi } from '@/app/GerAdv_TS/Fornecedores/Apis/ApiFornecedores';

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
    e.preventDefault();
    if (!isSubmitting) {
      setIsSubmitting(true);
      onSubmit(e);
    }
   };

  return (
  <>
  {nomeBensClassificacao && (<h2>{nomeBensClassificacao}</h2>)}
{nomeFornecedores && (<h2>{nomeFornecedores}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

    <Input
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={bensmateriaisData.nome}
            onChange={onChange}
            required
          />

            <BensClassificacaoComboBox
            name={'bensclassificacao'}
            value={bensmateriaisData.bensclassificacao}
            setValue={addValorBensClassificacao}
            label={'Bens Classificacao'}
            />

<Input
type="text"
id="datacompra"
label="DataCompra"
className="inputIncNome"
name="datacompra"
value={bensmateriaisData.datacompra}
onChange={onChange}               
/>

<Input
type="text"
id="datafimdagarantia"
label="DataFimDaGarantia"
className="inputIncNome"
name="datafimdagarantia"
value={bensmateriaisData.datafimdagarantia}
onChange={onChange}               
/>

<Input
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

<Input
type="text"
id="valorbem"
label="ValorBem"
className="inputIncNome"
name="valorbem"
value={bensmateriaisData.valorbem}
onChange={onChange}               
/>

<Input
type="text"
id="nroserieproduto"
label="NroSerieProduto"
className="inputIncNome"
name="nroserieproduto"
value={bensmateriaisData.nroserieproduto}
onChange={onChange}               
/>

<Input
type="text"
id="comprador"
label="Comprador"
className="inputIncNome"
name="comprador"
value={bensmateriaisData.comprador}
onChange={onChange}               
/>

<Input
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={bensmateriaisData.cidade}
onChange={onChange}               
/>

</div><div className="grid-container"><Checkbox label="GarantiaLoja" name="garantialoja" checked={bensmateriaisData.garantialoja} onChange={onChange} />
        
<Input
type="text"
id="dataterminodagarantiadaloja"
label="DataTerminoDaGarantiaDaLoja"
className="inputIncNome"
name="dataterminodagarantiadaloja"
value={bensmateriaisData.dataterminodagarantiadaloja}
onChange={onChange}               
/>

<Input
type="text"
id="observacoes"
label="Observacoes"
className="inputIncNome"
name="observacoes"
value={bensmateriaisData.observacoes}
onChange={onChange}               
/>

<Input
type="text"
id="nomevendedor"
label="NomeVendedor"
className="inputIncNome"
name="nomevendedor"
value={bensmateriaisData.nomevendedor}
onChange={onChange}               
/>

          </div>
           <div className="buttons-container">
              <br />
              <Button type="button" className="buttonSair" onClick={onClose}>
                Cancelar
              </Button>
              &nbsp;&nbsp;
              <Button type="submit" themeColor="primary" className="buttonOk" disabled={isSubmitting}>
                Salvar
              </Button>
          </div>
        </form>
    </div>
    </>
     );
};
 