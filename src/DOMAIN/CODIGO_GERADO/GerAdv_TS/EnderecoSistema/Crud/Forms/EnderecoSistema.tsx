"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IEnderecoSistema } from '../../Interfaces/interface.EnderecoSistema';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import TipoEnderecoSistemaComboBox from '@/app/GerAdv_TS/TipoEnderecoSistema/ComboBox/TipoEnderecoSistema';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { TipoEnderecoSistemaApi } from '@/app/GerAdv_TS/TipoEnderecoSistema/Apis/ApiTipoEnderecoSistema';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import InputCep from '@/app/components/Inputs/InputCep'

interface EnderecoSistemaFormProps {
    enderecosistemaData: IEnderecoSistema;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const EnderecoSistemaForm: React.FC<EnderecoSistemaFormProps> = ({
    enderecosistemaData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeTipoEnderecoSistema, setNomeTipoEnderecoSistema] = useState('');
            const tipoenderecosistemaApi = new TipoEnderecoSistemaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeProcessos, setNomeProcessos] = useState('');
            const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("tipoenderecosistema") > 0) {
  tipoenderecosistemaApi
    .getById(getParamFromUrl("tipoenderecosistema"))
    .then((response) => {
      setNomeTipoEnderecoSistema(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (enderecosistemaData.id === 0) {
    enderecosistemaData.tipoenderecosistema = getParamFromUrl("tipoenderecosistema");
  }
}
 
if (getParamFromUrl("processos") > 0) {
  processosApi
    .getById(getParamFromUrl("processos"))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

  if (enderecosistemaData.id === 0) {
    enderecosistemaData.processo = getParamFromUrl("processos");
  }
}
 const addValorTipoEnderecoSistema = (e: any) => {
                        if (e?.id>0)
                        enderecosistemaData.tipoenderecosistema = e.id;
                      };
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        enderecosistemaData.processo = e.id;
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
  {nomeTipoEnderecoSistema && (<h2>{nomeTipoEnderecoSistema}</h2>)}
{nomeProcessos && (<h2>{nomeProcessos}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

<Input
type="text"
id="cadastro"
label="Cadastro"
className="inputIncNome"
name="cadastro"
value={enderecosistemaData.cadastro}
onChange={onChange}               
/>

<Input
type="text"
id="cadastroexcod"
label="CadastroExCod"
className="inputIncNome"
name="cadastroexcod"
value={enderecosistemaData.cadastroexcod}
onChange={onChange}               
/>

            <TipoEnderecoSistemaComboBox
            name={'tipoenderecosistema'}
            value={enderecosistemaData.tipoenderecosistema}
            setValue={addValorTipoEnderecoSistema}
            label={'Tipo Endereco Sistema'}
            />

            <ProcessosComboBox
            name={'processo'}
            value={enderecosistemaData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

<Input
type="text"
id="motivo"
label="Motivo"
className="inputIncNome"
name="motivo"
value={enderecosistemaData.motivo}
onChange={onChange}               
/>

<Input
type="text"
id="contatonolocal"
label="ContatoNoLocal"
className="inputIncNome"
name="contatonolocal"
value={enderecosistemaData.contatonolocal}
onChange={onChange}               
/>

<Input
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={enderecosistemaData.cidade}
onChange={onChange}               
/>

<Input
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={enderecosistemaData.endereco}
onChange={onChange}               
/>

<Input
type="text"
id="bairro"
label="Bairro"
className="inputIncNome"
name="bairro"
value={enderecosistemaData.bairro}
onChange={onChange}               
/>

</div><div className="grid-container">        
<InputCep
type="text"
id="cep"
label="CEP"
className="inputIncNome"
name="cep"
value={enderecosistemaData.cep}
onChange={onChange}               
/>

<Input
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={enderecosistemaData.fone}
onChange={onChange}               
/>

<Input
type="text"
id="fax"
label="Fax"
className="inputIncNome"
name="fax"
value={enderecosistemaData.fax}
onChange={onChange}               
/>

<Input
type="text"
id="observacao"
label="Observacao"
className="inputIncNome"
name="observacao"
value={enderecosistemaData.observacao}
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
 