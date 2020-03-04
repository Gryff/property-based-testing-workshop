const fc = require('fast-check')

describe('sort', () => {
  it('sorts a simple array of 2, 3, 1', () => {
    const myArray = [2, 3, 1]
    expect(sort(myArray)).toEqual([1, 2, 3])
  })

  it('sorting is idempotent', () => {
    const myArray = [2, 3, 1]
    expect(sort(sort(myArray))).toEqual(sort(myArray))
  })

  it('sorting is idempotent - property based', () => {
    fc.assert(
      fc.property(
        fc.array(fc.integer()),
        myArray => sort(sort(myArray)) === sort(myArray)
      )
    )
  })
})

function sort (arr) {
  return arr.sort()
}
