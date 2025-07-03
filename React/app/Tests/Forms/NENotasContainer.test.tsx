import React from 'react';
import { render } from '@testing-library/react';
import NENotasIncContainer from '@/app/GerAdv_TS/NENotas/Components/NENotasIncContainer';
// NENotasIncContainer.test.tsx
// Mock do NENotasInc
jest.mock('@/app/GerAdv_TS/NENotas/Crud/Inc/NENotas', () => (props: any) => (
<div data-testid='nenotas-inc-mock' {...props} />
));
describe('NENotasIncContainer', () => {
  it('deve renderizar NENotasInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <NENotasIncContainer id={id} navigator={mockNavigator} />
  );
  const nenotasInc = getByTestId('nenotas-inc-mock');
  expect(nenotasInc).toBeInTheDocument();
  expect(nenotasInc.getAttribute('id')).toBe(id.toString());

});
});