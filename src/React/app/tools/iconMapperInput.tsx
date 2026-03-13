'use client';
import React from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { 
  faUser, faUserMd, faUserTie, faUsers, faUserCheck,
  faEnvelope, faPhone, faMobileAlt, faFax,
  faMapMarkerAlt, faHome, faBuilding, faCity, faFlag, faMapPin,
  faCalendarAlt, faClock, faCalendarCheck,
  faIdCard, faFileAlt, faFileContract, faFileSignature, faCertificate, faPassport,
  faMoneyBillWave, faDollarSign, faEuroSign, faYenSign, faPoundSign, faCreditCard, faCoins,
  faMedkit, faStethoscope, faHeartbeat, faPills, faSyringe, faXRay, faMicroscope,
  faBalanceScale, faGavel, faLandmark, faHandshake, faFileInvoiceDollar, faShieldAlt,
  faChartLine, faChartBar, faPercentage, faTags, faShoppingCart, faWarehouse,
  faWineGlass, faWineBottle, faFlask, faTint, faThermometerHalf,
  faDesktop, faLaptop, faServer, faNetworkWired, faCogs, faToolbox,
  faTicketAlt, faBug, faWrench, faTools, faHeadset, faLifeRing,
  faEye, faEyeSlash, faLock, faUnlock, faKey, faFingerprint,
  faSearch, faFilter, faSave, faEdit, faTrash, faPlus, faCheck, faTimes,
  faInfoCircle, faExclamationTriangle, faQuestionCircle, faStar,
  faBook, faGraduationCap, faUniversity, faPencilAlt, faClipboardList,
  faTruck, faShippingFast, faBoxes, faBarcode, faQrcode,
  faCamera, faImage, faVideo, faMusic, faFileImage, faFilePdf,
  faWifi, faPlug, faBattery, faSignal,
  faUserFriends, faComments, faComment, faShare, faHeart, faThumbsUp,
  faTemperatureLow, faTemperatureHigh, faWeight, faRuler, faCalculator,
  faBirthdayCake, faChild, faBaby, faFemale, faMale, faTransgender,
  faAmbulance, faHospital, faFirstAid, faPrescriptionBottle, faUserNurse,
  faBusinessTime, faBriefcase, faIndustry, faStore,
  faLeaf, faSeedling, faTree, faRecycle, faWater, faToggleOn, faToggleOff,
  faSignature, faVenusMars, faCross, faUserTimes, faStickyNote, faTriangleExclamation,
  faMoneyBill, faBoxOpen,
  faCheckCircle
} from '@fortawesome/free-solid-svg-icons';

const ICON_MAP: Record<string, any> = {
  // DADOS PESSOAIS
  'liberado': faUserCheck,
  'faltou': faUserTimes,
  'concluido': faCheckCircle,
  'concluida': faCheckCircle,
  'aprovado': faCheckCircle,
  'completo': faCheckCircle,
  'prontuario': faMedkit,
  'prontuário': faMedkit,
  'record': faMedkit,
  'historico': faMedkit,
  'paciente': faUser,  
  'formado': faGraduationCap,
  'recibo': faMoneyBill,
  'receipt': faMoneyBill,
  'comprovante': faMoneyBill,
  'importante': faCertificate,
  'important': faCertificate,
  'certidao': faCertificate,
  'nome': faUser,
  'name': faUser,
  'usuario': faUser,
  'colaborador': faUser,
  'funcionario': faUser,
  'employee': faUser,
  'staff': faUser,
  'user': faUser,
  'cliente': faUser,
  'customer': faUser,  
  'patient': faUser,
  'sobrenome': faSignature,
  'surname': faSignature,
  'lastname': faSignature,
  'apelido': faSignature,
  'nickname': faSignature,
  'rg': faIdCard,
  'identidade': faIdCard,
  'identity': faIdCard,
  'cpf': faFileAlt,
  'cnpj': faFileAlt,
  'tax': faFileAlt,
  'fiscal': faFileAlt,
  'passaporte': faPassport,
  'passport': faPassport,
  'nascimento': faBirthdayCake,
  'birth': faBirthdayCake,
  'aniversario': faBirthdayCake,
  'idade': faBirthdayCake,
  'age': faBirthdayCake,
  'sexo': faVenusMars,
  'gender': faVenusMars,
  'genero': faVenusMars,
  'civil': faHeart,
  'marital': faHeart,
  'estado': faHeart,

  // CONTATO
  'email': faEnvelope,
  'mail': faEnvelope,
  'correio': faEnvelope,
  'telefone': faPhone,
  'phone': faPhone,
  'fone': faPhone,
  'tel': faPhone,
  'celular': faMobileAlt,
  'mobile': faMobileAlt,
  'cell': faMobileAlt,
  'whatsapp': faMobileAlt,
  'fax': faFax,

  // ENDEREÇO
  'cep': faMapPin,
  'zip': faMapPin,
  'postal': faMapPin,
  'endereco': faHome,
  'address': faHome,
  'rua': faHome,
  'street': faHome,
  'bairro': faMapMarkerAlt,
  'district': faMapMarkerAlt,
  'cidade': faCity,
  'city': faCity,
  'municipio': faCity,
  'uf': faFlag,
  'pais': faFlag,
  'country': faFlag,
  'complemento': faBuilding,
  'numero': faBuilding,
  'number': faBuilding,

  // DATAS E TEMPO
  'data': faCalendarAlt,
  'date': faCalendarAlt,
  'dia': faCalendarAlt,
  'hora': faClock,
  'time': faClock,
  'horario': faClock,
  'agendamento': faCalendarCheck,
  'appointment': faCalendarCheck,
  'consulta': faCalendarCheck,

  // FINANCEIRO
  'valor': faDollarSign,
  'value': faDollarSign,
  'preco': faDollarSign,
  'price': faDollarSign,
  'custo': faDollarSign,
  'dinheiro': faMoneyBillWave,
  'money': faMoneyBillWave,
  'pagamento': faMoneyBillWave,
  'cartao': faCreditCard,
  'card': faCreditCard,
  'credito': faCreditCard,
  'desconto': faPercentage,
  'discount': faPercentage,
  'juros': faPercentage,
  'taxa': faPercentage,

  // MÉDICO/SAÚDE
  'medico': faUserMd,
  'doctor': faUserMd,
  'dr': faUserMd,  
  'pressao': faHeartbeat,
  'pressure': faHeartbeat,
  'batimento': faHeartbeat,
  'cardiaco': faHeartbeat,
  'medicamento': faPills,
  'medicine': faPills,
  'remedio': faPills,
  'vacina': faSyringe,
  'vaccine': faSyringe,
  'injecao': faSyringe,
  'raio': faXRay,
  'xray': faXRay,
  'imagem': faXRay,
  'tomografia': faXRay,
  'laboratorio': faMicroscope,
  'lab': faMicroscope,
  'analise': faMicroscope,
  'emergencia': faAmbulance,
  'urgencia': faAmbulance,
  'hospital': faHospital,
  'clinica': faHospital,
  'receita': faPrescriptionBottle,
  'prescription': faPrescriptionBottle,
  'enfermeiro': faUserNurse,
  'nurse': faUserNurse,
  'peso': faWeight,
  'weight': faWeight,
  'altura': faRuler,
  'height': faRuler,
  'temperatura': faThermometerHalf,
  'temp': faThermometerHalf,
  'febre': faThermometerHalf,

  // JURÍDICO/ADVOCACIA
  'processo': faBalanceScale,
  'case': faBalanceScale,
  'acao': faBalanceScale,
  'lawsuit': faBalanceScale,
  'juiz': faGavel,
  'judge': faGavel,
  'sentenca': faGavel,
  'tribunal': faLandmark,
  'court': faLandmark,
  'contrato': faFileContract,
  'contract': faFileContract,
  'acordo': faHandshake,
  'deal': faHandshake,
  'defesa': faShieldAlt,
  'defense': faShieldAlt,
  'assinatura': faFileSignature,
  'signature': faFileSignature,
  'advogado': faUserTie,
  'lawyer': faUserTie,
  'attorney': faUserTie,

  // CRM/VENDAS
  'clientes': faUsers,
  'customers': faUsers,
  'leads': faUsers,
  'vendas': faChartLine,
  'sales': faChartLine,
  'revenue': faChartLine,
  'negocio': faHandshake,
  'opportunity': faHandshake,
  'ligacao': faPhone,
  'call': faPhone,
  'tag': faTags,
  'etiqueta': faTags,
  'relatorio': faChartBar,
  'report': faChartBar,
  'dashboard': faChartBar,
  'pipeline': faBusinessTime,
  'funil': faBusinessTime,
  'empresa': faBriefcase,
  'company': faBriefcase,
  'business': faBriefcase,

  // VINÍCOLA
  'vinho': faWineGlass,
  'wine': faWineGlass,
  'tinto': faWineGlass,
  'branco': faWineGlass,
  'garrafa': faWineBottle,
  'bottle': faWineBottle,
  'rotulo': faWineBottle,
  'safra': faFlask,
  'harvest': faFlask,
  'vintage': faFlask,
  'degustacao': faTint,
  'tasting': faTint,
  'aroma': faTint,
  'adega': faWarehouse,
  'estoque': faWarehouse,
  'stock': faWarehouse,

  // TI/SUPORTE
  'ticket': faTicketAlt,
  'chamado': faTicketAlt,
  'solicitacao': faTicketAlt,
  'bug': faBug,
  'erro': faBug,
  'error': faBug,
  'problema': faBug,
  'manutencao': faWrench,
  'maintenance': faWrench,
  'reparo': faWrench,
  'computador': faDesktop,
  'computer': faDesktop,
  'desktop': faDesktop,
  'pc': faDesktop,
  'notebook': faLaptop,
  'laptop': faLaptop,
  'servidor': faServer,
  'server': faServer,
  'host': faServer,
  'rede': faNetworkWired,
  'network': faNetworkWired,
  'internet': faNetworkWired,
  'suporte': faHeadset,
  'support': faHeadset,
  'helpdesk': faHeadset,
  'ajuda': faLifeRing,
  'help': faLifeRing,
  'configuracao': faCogs,
  'config': faCogs,
  'settings': faCogs,
  'ferramentas': faToolbox,
  'tools': faToolbox,
  'seguranca': faShieldAlt,
  'security': faShieldAlt,
  'firewall': faShieldAlt,
  'senha': faKey,
  'password': faKey,
  'login': faKey,
  'bloqueado': faLock,
  'locked': faLock,
  'wifi': faWifi,
  'wireless': faWifi,
  'bateria': faBattery,
  'battery': faBattery,

  // SISTEMA/INTERFACE
  'buscar': faSearch,
  'search': faSearch,
  'pesquisar': faSearch,
  'filtro': faSearch,
  'salvar': faSave,
  'save': faSave,
  'gravar': faSave,
  'editar': faEdit,
  'edit': faEdit,
  'deletar': faTrash,
  'delete': faTrash,
  'remover': faTrash,
  'adicionar': faPlus,
  'add': faPlus,
  'novo': faPlus,
  'new': faPlus,
  'confirmar': faCheck,
  'confirm': faCheck,
  'ok': faCheck,
  'cancelar': faTimes,
  'cancel': faTimes,
  'fechar': faTimes,
  'informacao': faInfoCircle,
  'info': faInfoCircle,
  'alerta': faExclamationTriangle,
  'alert': faExclamationTriangle,
  'warning': faExclamationTriangle,
  'favorito': faStar,
  'favorite': faStar,
  'star': faStar,
  'visualizar': faEye,
  'view': faEye,
  'ver': faEye,
  'ocultar': faEyeSlash,
  'hide': faEyeSlash,
  'status': faToggleOn,
  'ativo': faToggleOn,
  'inativo': faToggleOff,
  'desistencia': faUserTimes,
  'desistente': faUserTimes,
  'obito': faCross,
  'morte': faCross,
  'observacao': faStickyNote,
  'observation': faStickyNote,
  'nota': faStickyNote,
  'note': faStickyNote,
  'comentario': faStickyNote,
  'profissao': faBriefcase,
  'profissional': faBriefcase,
  'profession': faBriefcase,

  // OUTROS
  'lista': faClipboardList,
  'list': faClipboardList,
  'codigo': faBarcode,
  'code': faBarcode,
  'qr': faQrcode,
  'qrcode': faQrcode,
  'entrega': faTruck,
  'delivery': faTruck,
  'frete': faTruck,
  'produto': faBoxes,
  'product': faBoxes,
  'item': faBoxes,
  'industria': faIndustry,
  'industry': faIndustry,
  'loja': faStore,
  'store': faStore,
  'shop': faStore,
  'calculo': faCalculator,
  'calculation': faCalculator,
  'quantidade': faCalculator,
  'qtde': faCalculator,
  'count': faCalculator
};

/**
 * Função principal para obter ícone baseado no label
 * @param label - Label do campo (ex: "Nome", "Email", "CPF")
 * @returns Ícone FontAwesome ou null se não encontrado
 */
export function getIcon(label: string): any | null {
  if (!label) return null;
  
  // Normaliza o label (remove acentos, espaços, converte para minúsculo)
  const normalized = normalizeLabel(label);
  
  // Busca direta no mapa
  if (ICON_MAP[normalized]) {
    return ICON_MAP[normalized];
  }
  
  // Busca por palavras-chave dentro do label
  for (const [key, icon] of Object.entries(ICON_MAP)) {
    if (normalized.includes(key) || key.includes(normalized)) {
      return icon;
    }
  }
  
  return null;
}

/**
 * Normaliza o label para busca no mapa
 */
function normalizeLabel(label: string): string {
  return label
    .toLowerCase()
    .normalize('NFD')
    .replace(/[\u0300-\u036f]/g, '') // Remove acentos
    .replace(/[^a-z0-9]/g, '') // Remove caracteres especiais
    .trim();
}

/**
 * Componente para exibir ícone de input
 * @param icon - Ícone FontAwesome a ser exibido
 */
interface InputIconProps {
  icon: any;
  inputText?: boolean
}

export const InputAwesomeIcon: React.FC<InputIconProps> = ({ icon, inputText = true }) => {
  // Se não há ícone disponível, não renderiza nada
  if (!icon) {
    return null;
  }
  
  return (
    <FontAwesomeIcon
      icon={icon}
      className={inputText ? "input-icon-text" : "input-icon"}
    />
  );
};