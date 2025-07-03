import React from 'react';
import { render } from '@testing-library/react';
import ProcessosParadosIncContainer from '@/app/GerAdv_TS/ProcessosParados/Components/ProcessosParadosIncContainer';
// ProcessosParadosIncContainer.test.tsx
// Mock do ProcessosParadosInc
jest.mock('@/app/GerAdv_TS/ProcessosParados/Crud/Inc/ProcessosParados', () => (props: any) => (
<div data-testid='processosparados-inc-mock' {...props} />
));
describe('ProcessosParadosIncContainer', () => {
  it('deve renderizar ProcessosParadosInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <ProcessosParadosIncContainer id={id} navigator={mockNavigator} />
  );
  const processosparadosInc = getByTestId('processosparados-inc-mock');
  expect(processosparadosInc).toBeInTheDocument();
  expect(processosparadosInc.getAttribute('id')).toBe(id.toString());

});
});