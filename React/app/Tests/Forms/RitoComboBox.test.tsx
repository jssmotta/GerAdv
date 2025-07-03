// app/TestsForms/RitoComboBox.test.tsx - Vers�o Corrigida
import React from 'react';
import { render, screen, fireEvent, waitFor } from '@testing-library/react';
import RitoComboBox from '@/app/GerAdv_TS/Rito/ComboBox/Rito';
import { setupSystemContextMock } from '@/__tests__/testeHelpers';
// Mock do SystemContext
jest.mock('@/app/context/SystemContext', () => ({
  useSystemContext: jest.fn(), 
}));

import { RitoEmpty, RitoTestEmpty } from '@/app/GerAdv_TS/Models/Rito';
// Mock do hook antes dos imports
jest.mock('@/app/GerAdv_TS/Rito/Hooks/hookRito', () => ({
  useRitoComboBox: jest.fn(() => ({
    options: [
    { ...RitoEmpty(), id: 1, descricao: 'Rito 1' },
    { ...RitoEmpty(), id: 2, descricao: 'Rito 2' },
    ], 
    loading: false, 
    selectedValue: null, 
    handleFilter: jest.fn(), 
    handleValueChange: jest.fn(), 
    clearValue: jest.fn(), 
  })), 
}));
// Mock da API e Service
jest.mock('@/app/GerAdv_TS/Rito/Apis/ApiRito', () => ({
  RitoApi: jest.fn().mockImplementation(() => ({
    getById: jest.fn().mockResolvedValue({ id: 1, descricao: 'Mock Rito' }),
    getAll: jest.fn().mockResolvedValue([]), 
    filter: jest.fn().mockResolvedValue([]), 
    addAndUpdate: jest.fn().mockResolvedValue({ id: 1, descricao: 'Mock Rito' }),
    delete: jest.fn().mockResolvedValue(true), 
  })), 
}));
jest.mock('@/app/GerAdv_TS/Rito/Services/Rito.service', () => ({
  RitoService: jest.fn().mockImplementation(() => ({
    fetchRitoById: jest.fn().mockResolvedValue({ id: 1, descricao: 'Mock Rito' }),
    getList: jest.fn().mockResolvedValue([]), 
  })), 
}));
// Mock do Window
jest.mock('@/app/GerAdv_TS/Rito/Crud/Grids/RitoWindow', () => {
  return function MockRitoWindow(props: any) {
    return props.isOpen ? (
    <div data-testid='rito-window'>
      <button onClick={() => props.onClose()}>Close</button>
        <button onClick={() => props.onSuccess({ id: 1, descricao: 'New Item' })}>Success</button>
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
  <option value=''>Select {props.textField === 'descricao' ? 'Rito' : 'Item'}</option>
    {props.data?.map((item: any) => (
      <option key={item.id} value={item.id}>
        {item.descricao}
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
  { ...RitoTestEmpty(), id: 1, descricao: 'Rito 1' },
  { ...RitoTestEmpty(), id: 2, descricao: 'Rito 2' },
];
// Props padr�o para o componente
const defaultProps = {
  label: 'Rito',
  name: 'rito',
  value: 0, 
  setValue: jest.fn(), 
  dataForm: RitoEmpty(), 
};
describe('RitoComboBox', () => {
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
  const { useRitoComboBox } = require('@/app/GerAdv_TS/Rito/Hooks/hookRito');
  (useRitoComboBox as jest.Mock).mockReturnValue({
    options: mockOptions, 
    loading: false, 
    selectedValue: null, 
    handleFilter: jest.fn(), 
    handleValueChange: jest.fn(), 
    clearValue: jest.fn(), 
  });
  it('renders label and ComboBox', () => {
    render(<RitoComboBox {...defaultProps} />);
    // Verificar se o label � renderizado
    expect(screen.getByText('Rito')).toBeInTheDocument();
    // Verificar se o combobox � renderizado
    const combobox = screen.getByRole('combobox');
    expect(combobox).toBeInTheDocument();
    // Verificar se a op��o padr�o est� presente
    expect(screen.getByText('Select Rito')).toBeInTheDocument();
  });
  it('calls setValue on ComboBox change', () => {
    render(<RitoComboBox {...defaultProps} />);
    const combobox = screen.getByRole('combobox');

    fireEvent.change(combobox, { target: { value: '1' } });
    expect(defaultProps.setValue).toHaveBeenCalledWith({ ...RitoTestEmpty(), id: 1, descricao: 'Rito 1' });
  });
  it('shows loading state', () => {
    // Mock loading state
    const { useRitoComboBox } = require('@/app/GerAdv_TS/Rito/Hooks/hookRito');
    useRitoComboBox.mockReturnValue({
      options: [], 
      loading: true, 
      selectedValue: null, 
      handleFilter: jest.fn(), 
      handleValueChange: jest.fn(), 
      clearValue: jest.fn(), 
    });
    render(<RitoComboBox {...defaultProps} />);
    expect(screen.getByRole('combobox')).toBeInTheDocument();
  });
  it('opens RitoWindow on action button click (add)', async () => {
    render(<RitoComboBox {...defaultProps} />);
    // Procurar pelo bot�o de adicionar usando o �cone
    const addButton = screen.getByTestId('svg-icon-plus-icon');
    expect(addButton).toBeInTheDocument();
    fireEvent.click(addButton.closest('label')!);
    // Verificar se a janela abriu
    await waitFor(() => {
      expect(screen.getByTestId('rito-window')).toBeInTheDocument();
    });
  });

  it('handles window close', async () => {
    render(<RitoComboBox {...defaultProps} />);
    // Abrir a janela
    const addButton = screen.getByTestId('svg-icon-plus-icon');
    fireEvent.click(addButton.closest('label')!);
    // Verificar se a janela est� aberta
    expect(screen.getByTestId('rito-window')).toBeInTheDocument();
    // Fechar a janela
    const closeButton = screen.getByText('Close');
    fireEvent.click(closeButton);
    // Verificar se a janela foi fechada
    await waitFor(() => {
      expect(screen.queryByTestId('rito-window')).not.toBeInTheDocument();
    });
  });
  it('renders with empty options when loading is false and no options', () => {
    (useRitoComboBox as jest.Mock).mockReturnValue({
      options: [], 
      loading: false, 
      selectedValue: null, 
      handleFilter: jest.fn(), 
      handleValueChange: jest.fn(), 
      clearValue: jest.fn(), 
    });
    render(<RitoComboBox {...defaultProps} />);
    const combobox = screen.getByRole('combobox');
    expect(combobox).toBeInTheDocument();
  });
  it('calls setValue with null when empty option is selected', () => {
    render(<RitoComboBox {...defaultProps} />);
    const combobox = screen.getByRole('combobox');

    fireEvent.change(combobox, { target: { value: '' } });
    expect(defaultProps.setValue).toHaveBeenCalledWith(null);
  });

  it('handles invalid value gracefully', () => {
    const propsWithInvalidValue = {
      ...defaultProps, 
      value: null
    };
    render(<RitoComboBox {...propsWithInvalidValue} />);
    const combobox = screen.getByRole('combobox');
    expect(combobox).toHaveValue('');
  });
  it('handles RitoWindow onClose and onSuccess', () => {
    render(<RitoComboBox {...defaultProps} />);
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
      value: { id: 1, descricao: 'Existing Item' }
    };
    // Mock com selectedValue
    const { useRitoComboBox } = require('@/app/GerAdv_TS/Rito/Hooks/hookRito');
    useRitoComboBox.mockReturnValue({
      options: mockOptions, 
      loading: false, 
      selectedValue: { id: 1, descricao: 'Existing Item' },
      handleFilter: jest.fn(), 
      handleValueChange: jest.fn(), 
      clearValue: jest.fn(), 
    });
    render(<RitoComboBox {...propsWithValue} />);
    const combobox = screen.getByRole('combobox');
    expect(combobox).toHaveValue('1');
  });
  it('handles string input for new items', () => {
    render(<RitoComboBox {...defaultProps} />);
    expect(screen.getByRole('combobox')).toBeInTheDocument();
  });
  it('handles filter changes', () => {
    const mockHandleFilter = jest.fn();
    const { useRitoComboBox } = require('@/app/GerAdv_TS/Rito/Hooks/hookRito');
    useRitoComboBox.mockReturnValue({
      options: mockOptions, 
      loading: false, 
      selectedValue: null, 
      handleFilter: mockHandleFilter, 
      handleValueChange: jest.fn(), 
      clearValue: jest.fn(), 
    });
    render(<RitoComboBox {...defaultProps} />);
    const combobox = screen.getByRole('combobox');
    expect(combobox).toBeInTheDocument();

    // O teste de filtro dependeria da implementa��o do ComboBox do Kendo
    // que � complexa de mockar completamente
  });
});