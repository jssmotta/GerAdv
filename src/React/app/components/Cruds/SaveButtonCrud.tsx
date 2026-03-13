import React, { ReactNode, use, useEffect, useMemo, useRef, useState } from 'react';
import { Button } from '@progress/kendo-react-buttons';
import PortalToElement from './PortalToElement'; // Certifique-se de que o caminho está correto
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import { saveIcon, cancelIcon, xIcon } from '@progress/kendo-svg-icons';
import {
  NotificationService,
  NotifySystemActions,
} from '@/app/tools/NotifySystem';
import ErrorMessage from './ErrorMessage';
import { useAppSelector } from '@/app/store/hooks';
import { selectSystemContext } from '@/app/store/slices/systemContextSlice';
import { SvgIcon } from '@progress/kendo-react-common';

interface SaveButtonCrudProps {
  isSubmitting: boolean;
  setIsSubmitting: any;
  onClose: () => void;
  children?: ReactNode;
  formId: string;
  entity?: string;
  timeOutOffInitial?: number; // Nova propriedade para controlar o tempo de timeout após a inicialização
  data: any;
  preventPropagation?: boolean; // Nova propriedade para controlar a propagação
  onSave?: () => void; // Callback opcional para ações de salvamento diretas
  onCancel?: () => void;
  validationForm: any; // Função de validação opcional
  isMobile?: boolean; // Propriedade opcional para indicar se é mobile
  bottomMobile?: boolean; // Propriedade opcional para indicar se os botões devem ficar na parte inferior em mobile
}

const SaveButtonCrud: React.FC<SaveButtonCrudProps> = ({
  isSubmitting,
  setIsSubmitting,
  timeOutOffInitial,
  onClose,
  onCancel,
  formId,
  entity,
  data,
  children,
  validationForm,
  isMobile,
  bottomMobile,
  preventPropagation = false, // Padrão: false para manter compatibilidade
  onSave,
}) => {
  const systemContext = useAppSelector(selectSystemContext);
  const [isCancelModalOpen, setIsCancelModalOpen] = React.useState(false);
  const [isModalOpen, setIsModalOpen] = React.useState(false);
  const [targetSelector, setTargetSelect] = React.useState<string>(
    '.k-window-titlebar-actions'
  );
  const [errorMessage, setErrorMessage] = useState<string | null>(null);
  const className = 'buttons-container';
  // useRef em vez de useState para evitar re-renders e loops de efeito
  const timeInitializedRef = useRef<Date | null>(null);
  const initialDataRef = useRef(data);
  const PMaxAgeLoadFormInMilliseconds = 500;
  const formRef = useRef<HTMLFormElement | null>(null);
  const isInitializingRef = useRef(!!timeOutOffInitial);
  const currentDataRef = useRef(data);
  currentDataRef.current = data;

  const notificationService = new NotificationService();

  useEffect(() => {
    setTargetSelect('.k-window-titlebar-actions');
  }, [isMobile]);

  // useMemo: deriva changedData sem setState — elimina completamente o loop
  // useEffect+setState com dep [data] causava: setState → re-render → nova ref data → effect → setState → loop
  const changedData = useMemo(() => {
    if (!timeInitializedRef.current || isInitializingRef.current) return false;
    const timeDifference = new Date().getTime() - timeInitializedRef.current.getTime();
    if (timeDifference <= PMaxAgeLoadFormInMilliseconds) return false;
    return JSON.stringify(data) !== JSON.stringify(initialDataRef.current);
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [data]);

  const notifyNoChanges = () => {
    if (!isMobile) {
      notificationService.notify({
        entity: entity ?? 'System',
        id: data?.id ?? 0,
        action: NotifySystemActions.INFO,
        message: 'Nenhuma alteração foi realizada.',
      });
    }
  };

  // Captura baseline apenas na montagem ou quando muda a entidade (data.id).
  // Usa refs para não gerar novas dependências que re-disparariam o effect de comparação.
  useEffect(() => {
    initialDataRef.current = data;
    timeInitializedRef.current = new Date();
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [data?.id]);

  // Efeito para obter referência ao formulário
  useEffect(() => {
    formRef.current = document.getElementById(formId) as HTMLFormElement;
  }, [formId]);

  const onPressSalvar = async (e: React.MouseEvent<HTMLButtonElement>) => {
    e.preventDefault();

    // Prevenindo propagação se necessário
    if (preventPropagation) {
      e.stopPropagation();
    }

    // Se não houve alterações, apenas fecha    

    if (!changedData && data.id !== 0) {
      notifyNoChanges();
      if (onClose) {
        onClose();
      }
      return;
    }

    // Se não está já enviando, mostra o modal de confirmação
    if (!isSubmitting) {

      var backendValidation = await validationForm.runValidation(data, systemContext?.TenantApp, systemContext?.Token);
    
      if (!backendValidation.isValid)  {
        setErrorMessage(backendValidation.message);
        setIsSubmitting(false);
        return;
      }

      var validate = validationForm.validate(data);

      if (!validate.isValid) {
        setErrorMessage(validate.message);
        setIsSubmitting(false);
        return;
      }

      setIsModalOpen(true);
    }
  };

  const onPressCancelar = (e: React.MouseEvent<HTMLButtonElement>) => {
    e.preventDefault();

    if (preventPropagation) {
      e.stopPropagation();
    }

    // Se houve alterações, mostra modal de confirmação
    if (changedData) {
      setIsCancelModalOpen(true);
    } else {
      // Se não houve alterações, apenas fecha

      if (onClose) {
        onClose();
      }
    }
  };

  // NOVO: Função para confirmar o cancelamento
  const confirmCancelButton = () => {
    setIsCancelModalOpen(false);

    // Se há um callback de cancelamento personalizado, usa ele
    if (onCancel) {
      onCancel();
    } else {
      // Comportamento padrão: apenas fecha
      if (onClose) {
        onClose();
      }
    }
  };

  // NOVO: Função para cancelar o cancelamento (não fazer nada)
  const cancelCancelButton = () => {
    setIsCancelModalOpen(false);
  };

  // Função que lida com a confirmação do salvamento
  const confirmButton = () => {
    setIsModalOpen(false);

    // Se temos um callback de salvamento direto, usamos ele
    if (onSave) {
      onSave();

      return;
    }

    // Garantimos que temos acesso ao formulário
    if (!formRef.current) {
      formRef.current = document.getElementById(formId) as HTMLFormElement;
    }

    if (formRef.current) {
      // Criamos um evento de submissão
      const submissionEvent = new SubmitEvent('submit', {
        bubbles: !preventPropagation, // Não propaga se preventPropagation=true
        cancelable: true,
        submitter: null, // Define submitter as null or the triggering element if available
      });

      try {
        // Primeiro verificamos se o formulário tem um método onsubmit direto
        if (typeof formRef.current.onsubmit === 'function') {
          const result = formRef.current.onsubmit(submissionEvent);

          // Se o manipulador retornou false ou o padrão foi prevenido, não continuamos
          if (result === false || submissionEvent.defaultPrevented) {
            return;
          }
        }

        // Se chegamos aqui, podemos proceder com o envio programático
        // Encontramos o handler onSubmit do React pelos atributos de dados
        const reactHandler = Object.keys(formRef.current).find(
          (key) =>
            key.startsWith('__reactEventHandlers') ||
            key.startsWith('__reactProps')
        );

        if (reactHandler && formRef.current[reactHandler]?.onSubmit) {
          // Chamamos o handler React diretamente se existir
          formRef.current[reactHandler].onSubmit(submissionEvent);
        } else {
          // Caso contrário, usamos submit nativo (menos ideal para formulários React)
          formRef.current.submit();
        }
      } catch (error) {
         if (process.env.NEXT_PUBLIC_SHOW_LOG === '1') {
          console.error('Erro ao submeter formulário:', error);
         }
      }
    }
  };

  const cancelButton = () => {
    setIsModalOpen(false);
  };

  useEffect(() => {
    if (timeOutOffInitial) {
      isInitializingRef.current = true;
      const timer = setTimeout(() => {
        isInitializingRef.current = false;
        // Recaptura o baseline com os dados atuais (após carregamento da API)
        // changedData é useMemo — recalcula automaticamente no próximo render
        initialDataRef.current = currentDataRef.current;
      }, timeOutOffInitial);
      return () => clearTimeout(timer);
    }
  }, [timeOutOffInitial]);

  
          {'// affordance progressiva'}
          
  return (
    <>
      <ErrorMessage mensagem={errorMessage} setErrorMessage={setErrorMessage} />

      <ConfirmationModal
        isOpen={isModalOpen}
        onConfirm={confirmButton}
        onCancel={cancelButton}
        message={'Confirma a gravação dos dados?'}
      />
      <ConfirmationModal
        isOpen={isCancelModalOpen}
        onConfirm={confirmCancelButton}
        onCancel={cancelCancelButton}
        message={
          'Há alterações não salvas. Deseja realmente cancelar e perder as alterações?'
        }
      />
      {data && isMobile && !bottomMobile && (
        <>
          <PortalToElement
            targetSelector={targetSelector}
            className={`unique-portal-class-${data?.id ?? 0}`}
            formId={formId}
          >
            <div style={{ backgroundColor: 'transparent', border: 'none', padding: 0, boxShadow: 'none', WebkitBoxShadow: 'none' }}
              className={`unique-portal-class-${data?.id ?? 0} ${className} buttons-container-portal`}
            > 
              <SvgIcon
                className={`disk-save-mobile ${changedData ? 'blink' : ''}`}
                icon={saveIcon}
                size="large"
                style={{ width: '30px', height: '30px' }}
                onClick={onPressSalvar}
              />

              {children}
            </div>
          </PortalToElement>
        </>
      )}

      

      {data && isMobile && bottomMobile && (
        <>


          <style>
            {`       

                        .buttonCrudOk.disabled {
                            opacity: 0.5 !important;
                            pointer-events: none !important;
                        }         
                    `}
          </style>

          <div className="button-delete-inc">
             
            <Button
              className="button-cadinc button-after-button"
              type="button"
              aria-label="Salvar"
              disabled={
                isSubmitting ||
                (data !== null &&
                  data.nome !== undefined &&
                  data.nome.length === 0)
              }
              onClick={onPressSalvar}
              title='Clique para gravar os dados após confirmação'              
            >
              <span className="colorCrudTextButton"> 
                
                <SvgIcon className='disk-save-mobile' icon={saveIcon} size="medium" style={{ width: '18px', height: '18px' }}  onClick={onPressSalvar} />

              &nbsp;&nbsp;&nbsp;&nbsp;SALVAR</span>
            </Button>
          </div>
        </>
      )}

      {data && !isMobile && (
        <>
          <PortalToElement
            targetSelector={targetSelector}
            className={`unique-portal-class-${data?.id ?? 0}`}
            formId={formId}
          >
            <div
              className={`unique-portal-class-${data?.id ?? 0} ${className} buttons-container-portal`}
            >
              <br />
              <Button
                type="button"
                aria-label="Cancelar"
                className="buttonSair buttonCrudSair"
                title='Clique para cancelar a edição/adição dos dados'
                onClick={(e) => {
                  if (preventPropagation) e.stopPropagation();
                  onPressCancelar(e);
                }}
                svgIcon={cancelIcon}
              >
                &nbsp;&nbsp;&nbsp;&nbsp;
                <span className="colorCrudTextButton">Cancelar</span>
              </Button>
              &nbsp;&nbsp;
              <Button
                type="button" // Mantido como button para controlar o comportamento
                themeColor="primary"
                aria-label="Salvar"
                title='Clique para gravar os dados após confirmação'
                className="buttonOk buttonCrudOk"
                disabled={
                  isSubmitting ||
                  (data !== null &&
                    data.nome !== undefined &&
                    data.nome.length === 0)
                }
                onClick={onPressSalvar}
                svgIcon={saveIcon}
                style={{
                  color: '#fff',
                  cursor: 'pointer',
                }}
              >
                &nbsp;&nbsp;&nbsp;&nbsp;
                <span className="colorCrudTextButton">Salvar</span>
              </Button>
              {children}
            </div>
          </PortalToElement>
        </>
      )}
    </>
  );
};

export default SaveButtonCrud;
