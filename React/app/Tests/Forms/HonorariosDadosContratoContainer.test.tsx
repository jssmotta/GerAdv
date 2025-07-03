import React from 'react';
import { render } from '@testing-library/react';
import HonorariosDadosContratoIncContainer from '@/app/GerAdv_TS/HonorariosDadosContrato/Components/HonorariosDadosContratoIncContainer';
// HonorariosDadosContratoIncContainer.test.tsx
// Mock do HonorariosDadosContratoInc
jest.mock('@/app/GerAdv_TS/HonorariosDadosContrato/Crud/Inc/HonorariosDadosContrato', () => (props: any) => (
<div data-testid='honorariosdadoscontrato-inc-mock' {...props} />
));
describe('HonorariosDadosContratoIncContainer', () => {
  it('deve renderizar HonorariosDadosContratoInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <HonorariosDadosContratoIncContainer id={id} navigator={mockNavigator} />
  );
  const honorariosdadoscontratoInc = getByTestId('honorariosdadoscontrato-inc-mock');
  expect(honorariosdadoscontratoInc).toBeInTheDocument();
  expect(honorariosdadoscontratoInc.getAttribute('id')).toBe(id.toString());

});
});