  // Map agenda items to Kendo Scheduler events
  // Mapeamento de cores por ID do ícone (baseado nas imagens fornecidas)
  export const getIconColor = (iconId: number): string => {
    const iconColors: { [key: number]: string } = {
      0: '#ffffff',  // Marrom - ícone padrão
      1: '#FF6B6B',  // Vermelho coral - consulta
      2: '#4ECDC4',  // Turquesa - exame
      3: '#45B7D1',  // Azul - procedimento
      4: '#96CEB4',  // Verde menta - retorno
      5: '#FFEAA7',  // Amarelo suave - orientação
      6: '#DDA0DD',  // Roxo claro - especialista
      7: '#F4A460',  // Laranja sandy - urgência
      8: '#98D8C8',  // Verde água - terapia
      9: '#F7DC6F',  // Amarelo ouro - vacina
      10: '#BB8FCE', // Lilás - psicologia
      11: '#85C1E9', // Azul claro - cardiologia
      12: '#F8C471', // Pêssego - pediatria
      13: '#82E0AA', // Verde claro - nutrição
      14: '#F1948A', // Rosa salmão - ginecologia
      15: '#85929E', // Cinza azulado - neurologia
      16: '#D7BDE2', // Lavanda - psiquiatria
      17: '#A9DFBF', // Verde pastel - fisioterapia
      18: '#F9E79F', // Amarelo claro - oftalmologia
      19: '#D5A6BD', // Rosa antigo - dermatologia
      20: '#AED6F1', // Azul bebê - ortopedia
      21: '#FAD7A0', // Bege dourado - otorrino
      22: '#C39BD3', // Roxo médio - endocrinologia
      23: '#7FB3D3', // Azul acinzentado - urologia
      24: '#F0B27A', // Laranja claro - proctologia
      25: '#A3E4D7', // Verde água claro - pneumologia
      26: '#D2B4DE', // Roxo pastel - hematologia
      27: '#AEB6BF', // Cinza médio - radiologia
      28: '#F8D7DA', // Rosa muito claro - mastologia
      29: '#D4EDDA', // Verde muito claro - infectologia
      30: '#CCE5FF', // Azul muito claro - anestesiologia
      31: '#FFE4E6', // Rosa bebê - geriatria
      32: '#a11c25ff', // Rosa bebê - geriatria
    };
    
    return iconColors[iconId] || iconColors[0]; // Retorna cor padrão se ID não encontrado
  };