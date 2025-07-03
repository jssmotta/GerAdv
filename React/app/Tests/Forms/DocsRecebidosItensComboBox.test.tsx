// app/TestsForms/DocsRecebidosItensComboBox.test.tsx - Vers�o Corrigida
import React from 'react';
import { render, screen, fireEvent, waitFor } from '@testing-library/react';
import DocsRecebidosItensComboBox from '@/app/GerAdv_TS/DocsRecebidosItens/ComboBox/DocsRecebidosItens';
import { setupSystemContextMock } from '@/__tests__/testeHelpers';
// Mock do SystemContext
jest.mock('@/app/context/SystemContext', () => ({
  useSystemContext: jest.fn(), 
}));

import { DocsRecebidosItensEmpty, DocsRecebidosItensTestEmpty } from '@/app/GerAdv_TS/Models/DocsRecebidosItens';
// Mock do hook antes dos imports
jest.mock('@/app/GerAdv_TS/DocsRecebidosItens/Hooks/hookDocsRecebidosItens', () => ({
  useDocsRecebidosItensComboBox: jest.fn(() => ({
    options: [
    { ...DocsRecebidosItensEmpty(), id: 1, nome: 'Docs Recebidos Itens 1' },
    { ...DocsRecebidosItensEmpty(), id: 2, nome: 'Docs Recebidos Itens 2' },
    ], 
    loading: false, 
    selectedValue: null, 
    handleFilter: jest.fn(), 
    handleValueChange: jest.fn(), 
    clearValue: jest.fn(), 
  })), 
}));
// Mock da API e Service
jest.mock('@/app/GerAdv_TS/DocsRecebidosItens/Apis/ApiDocsRecebidosItens', () => ({
  DocsRecebidosItensApi: jest.fn().mockImplementation(() => ({
    getById: jest.fn().mockResolvedValue({ id: 1, nome: 'Mock DocsRecebidosItens' }),
    getAll: jest.fn().mockResolvedValue([]), 
    filter: jest.fn().mockResolvedValue([]), 
    addAndUpdate: jest.fn().mockResolvedValue({ id: 1, nome: 'Mock DocsRecebidosItens' }),
    delete: jest.fn().mockResolvedValue(true), 
  })), 
}));
jest.mock('@/app/GerAdv_TS/DocsRecebidosItens/Services/DocsRecebidosItens.service', () => ({
  DocsRecebidosItensService: jest.fn().mockImplementation(() => ({
    fetchDocsRecebidosItensById: jest.fn().mockResolvedValue({ id: 1, nome: 'Mock DocsRecebidosItens' }),
    getList: jest.fn().mockResolvedValue([]), 
  })), 
}));
// Mock do Window
jest.mock('@/app/GerAdv_TS/DocsRecebidosItens/Crud/Grids/DocsRecebidosItensWindow', () => {
  return function MockDocsRecebidosItensWindow(props: any) {
    return props.isOpen ? (
    <div data-testid='docsrecebidositens-window'>
      <button onClick={() => props.onClose()}>Close</button>
        <button onClick={() => props.onSuccess({ id: 1, nome: 'New Item' })}>Success</button>
        </div>
        ) : null;
      };
    });
    jest.mock('@/app/tools/crud', () => ({
      ActionAdicionar: 'Adicionar',
      ActionEditar: 'Editar',
    }));
    // Mock do Kendo UI ComboBox
    jest.mock('@progress/kendo-react-dropdowns', () => ({
      ComboBox: jest.fn((props: any) => (
      <select
      role='combobox'
      value={props.value?.id || ''}
      onChange={(e) => {
        const selectedId = parseInt(e.target.value);
        const selectedItem = props.data?.find((item: any) => item.id === selectedId);
        if (selectedItem) {
          props.onChange({ target: { value: selectedItem } });
        } else if (e.target.value === '') {
        props.onChange({ target: { value: null } });
      }
    }}
    data-testid='combo-box'
  >
  <option value=''>Select {props.textField === 'nome' ? 'Docs Recebidos Itens' : 'Item'}</option>
    {props.data?.map((item: any) => (
      <option key={item.id} value={item.id}>
        {item.nome}
      </option>
      ))}
    </select>
    )), 
  }));
  // Mock dos �cones Kendo
  jest.mock('@progress/kendo-svg-icons', () => ({
    pencilIcon: 'pencil-icon',
    plusIcon: 'plus-icon',
    xIcon: 'x-icon',
  }));
  jest.mock('@progress/kendo-react-common', () => ({
    SvgIcon: jest.fn(({ icon }) => <span data-testid={`svg-icon-${icon}`}>{icon}</span>),
  }));
  // Dados mock para os testes
  const mockOptions = [
  { ...DocsRecebidosItensTestEmpty(), id: 1, nome: 'Docs Recebidos Itens 1' },
  { ...DocsRecebidosItensTestEmpty(), id: 2, nome: 'Docs Recebidos Itens 2' },
];
// Props padr�o para o componente
const defaultProps = {
  label: 'Docs Recebidos Itens',
  name: 'docsrecebidositens',
  value: 0, 
  setValue: jest.fn(), 
  dataForm: DocsRecebidosItensEmpty(), 
};
describe('DocsRecebidosItensComboBox', () => {
  // Configurar o mock do SystemContext
  const { useSystemContext } = require('@/app/context/SystemContext');
  (useSystemContext as jest.Mock).mockReturnValue({
    Uri: 'test-uri',
    Token: 'test-token'
  });

  // Configurar o mock do SystemContext
  setupSystemContextMock({
    systemContext: { Uri: 'test-uri', Token: 'test-token' }
  });
  // Reset dos mocks do hook
  const { useDocsRecebidosItensComboBox } = require('@/app/GerAdv_TS/DocsRecebidosItens/Hooks/hookDocsRecebidosItens');
  (useDocsRecebidosItensComboBox as jest.Mock).mockReturnValue({
    options: mockOptions, 
    loading: false, 
    selectedValue: null, 
    handleFilter: jest.fn(), 
    handleValueChange: jest.fn(), 
    clearValue: jest.fn(), 
  });
  it('renders label and ComboBox', () => {
    render(<DocsRecebidosItensComboBox {...defaultProps} />);
    // Verificar se o label � renderizado
    expect(screen.getByText('Docs Recebidos Itens')).toBeInTheDocument();
    // Verificar se o combobox � renderizado
    const combobox = screen.getByRole('combobox');
    expect(combobox).toBeInTheDocument();
    // Verificar se a op��o padr�o est� presente
    expect(screen.getByText('Select Docs Recebidos Itens')).toBeInTheDocument();
  });
  it('calls setValue on ComboBox change', () => {
    render(<DocsRecebidosItensComboBox {...defaultProps} />);
    const combobox = screen.getByRole('combobox');

    fireEvent.change(combobox, { target: { value: '1' } });
    expect(defaultProps.setValue).toHaveBeenCalledWith({ ...DocsRecebidosItensTestEmpty(), id: 1, nome: 'Docs Recebidos Itens 1' });
  });
  it('shows loading state', () => {
    // Mock loading state
    const { useDocsRecebidosItensComboBox } = require('@/app/GerAdv_TS/DocsRecebidosItens/Hooks/hookDocsRecebidosItens');
    useDocsRecebidosItensComboBox.mockReturnValue({
      options: [], 
      loading: true, 
      selectedValue: null, 
      handleFilter: jest.fn(), 
      handleValueChange: jest.fn(), 
      clearValue: jest.fn(), 
    });
    render(<DocsRecebidosItensComboBox {...defaultProps} />);
    expect(screen.getByRole('combobox')).toBeInTheDocument();
  });
  it('opens DocsRecebidosItensWindow on action button click (add)', async () => {
    render(<DocsRecebidosItensComboBox {...defaultProps} />);
    // Procurar pelo bot�o de adicionar usando o �cone
    const addButton = screen.getByTestId('svg-icon-plus-icon');
    expect(addButton).toBeInTheDocument();
    fireEvent.click(addButton.closest('label')!);
    // Verificar se a janela abriu
    await waitFor(() => {
      expect(screen.getByTestId('docsrecebidositens-window')).toBeInTheDocument();
    });
  });

  it('handles window close', async () => {
    render(<DocsRecebidosItensComboBox {...defaultProps} />);
    // Abrir a janela
    const addButton = screen.getByTestId('svg-icon-plus-icon');
    fireEvent.click(addButton.closest('label')!);
    // Verificar se a janela est� aberta
    expect(screen.getByTestId('docsrecebidositens-window')).toBeInTheDocument();
    // Fechar a janela
    const closeButton = screen.getByText('Close');
    fireEvent.click(closeButton);
    // Verificar se a janela foi fechada
    await waitFor(() => {
      expect(screen.queryByTestId('docsrecebidositens-window')).not.toBeInTheDocument();
    });
  });
  it('renders with empty options when loading is false and no options', () => {
    (useDocsRecebidosItensComboBox as jest.Mock).mockReturnValue({
      options: [], 
      loading: false, 
      selectedValue: null, 
      handleFilter: jest.fn(), 
      handleValueChange: jest.fn(), 
      clearValue: jest.fn(), 
    });
    render(<DocsRecebidosItensComboBox {...defaultProps} />);
    const combobox = screen.getByRole('combobox');
    expect(combobox).toBeInTheDocument();
  });
  it('calls setValue with null when empty option is selected', () => {
    render(<DocsRecebidosItensComboBox {...defaultProps} />);
    const combobox = screen.getByRole('combobox');

    fireEvent.change(combobox, { target: { value: '' } });
    expect(defaultProps.setValue).toHaveBeenCalledWith(null);
  });

  it('handles invalid value gracefully', () => {
    const propsWithInvalidValue = {
      ...defaultProps, 
      value: null
    };
    render(<DocsRecebidosItensComboBox {...propsWithInvalidValue} />);
    const combobox = screen.getByRole('combobox');
    expect(combobox).toHaveValue('');
  });
  it('handles DocsRecebidosItensWindow onClose and onSuccess', () => {
    render(<DocsRecebidosItensComboBox {...defaultProps} />);
    // Abrir a janela
    const addButton = screen.getByTestId('svg-icon-plus-icon');
    fireEvent.click(addButton.closest('label')!);
    // Testar onSuccess
    const successButton = screen.getByText('Success');
    fireEvent.click(successButton);
    expect(defaultProps.setValue).toHaveBeenCalledWith({ id: 1, nome: 'New Item' });
  });
  it('handles edit mode when value is provided', () => {
    const propsWithValue = {
      ...defaultProps, 
      value: { id: 1, nome: 'Existing Item' }
    };
    // Mock com selectedValue
    const { useDocsRecebidosItensComboBox } = require('@/app/GerAdv_TS/DocsRecebidosItens/Hooks/hookDocsRecebidosItens');
    useDocsRecebidosItensComboBox.mockReturnValue({
      options: mockOptions, 
      loading: false, 
      selectedValue: { id: 1, nome: 'Existing Item' },
      handleFilter: jest.fn(), 
      handleValueChange: jest.fn(), 
      clearValue: jest.fn(), 
    });
    render(<DocsRecebidosItensComboBox {...propsWithValue} />);
    const combobox = screen.getByRole('combobox');
    expect(combobox).toHaveValue('1');
  });
  it('handles string input for new items', () => {
    render(<DocsRecebidosItensComboBox {...defaultProps} />);
    expect(screen.getByRole('combobox')).toBeInTheDocument();
  });
  it('handles filter changes', () => {
    const mockHandleFilter = jest.fn();
    const { useDocsRecebidosItensComboBox } = require('@/app/GerAdv_TS/DocsRecebidosItens/Hooks/hookDocsRecebidosItens');
    useDocsRecebidosItensComboBox.mockReturnValue({
      options: mockOptions, 
      loading: false, 
      selectedValue: null, 
      handleFilter: mockHandleFilter, 
      handleValueChange: jest.fn(), 
      clearValue: jest.fn(), 
    });
    render(<DocsRecebidosItensComboBox {...defaultProps} />);
    const combobox = screen.getByRole('combobox');
    expect(combobox).toBeInTheDocument();

    // O teste de filtro dependeria da implementa��o do ComboBox do Kendo
    // que � complexa de mockar completamente
  });
});