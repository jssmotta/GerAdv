import React from 'react';
import { render } from '@testing-library/react';
import CargosIncContainer from '@/app/GerAdv_TS/Cargos/Components/CargosIncContainer';
// CargosIncContainer.test.tsx
// Mock do CargosInc
jest.mock('@/app/GerAdv_TS/Cargos/Crud/Inc/Cargos', () => (props: any) => (
<div data-testid='cargos-inc-mock' {...props} />
));
describe('CargosIncContainer', () => {
  it('deve renderizar CargosInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <CargosIncContainer id={id} navigator={mockNavigator} />
  );
  const cargosInc = getByTestId('cargos-inc-mock');
  expect(cargosInc).toBeInTheDocument();
  expect(cargosInc.getAttribute('id')).toBe(id.toString());

});
});